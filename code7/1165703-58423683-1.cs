        /// <summary>
        /// This method finds all namespace declarations on the descendants of the given root XElement
        /// and moves them from the decendant elements to the root element. It is thus possible to 
        /// make the XML string much smaller and more human-readable in cases when there are many
        /// redundant declarations of the same namespace.
        /// </summary>
        /// <param name="xRoot">The element whose descendants are to have their namespaces declarations
        /// removed. Also, the element that is to contain the consolidated namespace declarations</param>
        /// <param name="valueChangingAttribNames">A list of the names of XAttributes whose value
        /// must be updated to reflect changes to the namespace prefixes.
        /// This is designed to handle cases like d7p1 in the example:
        ///     xmlns:d7p1="http://www.w3.org/2001/XMLSchema" i:type="d7p1:int"
        /// generated by System.Runtime.Serialization.DataContractSerializer. In order to treat this
        /// example, the XName of the i:type attribute should be included in the list.  If the value
        /// of the 'valueChangingAttribNames' parameter is null, then no such changes are made to the
        /// values of XAttributes.  The default is null.
        /// </param>
        public static void ConsolidateNamespaces(this XElement xRoot,
                                List<XName> valueChangingAttribNames = null)
        {
            String letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            // Find all XAttributes that represent namespace declarations
            var nsAttributes = xRoot.Descendants().SelectMany(e => e.Attributes())
                        .Where(a => a.IsNamespaceDeclaration).ToList();
            // create groupings by common prefix
            var prefixGroups = nsAttributes.GroupBy(a => a.Name.LocalName);
            // Each time an XAttribute is resolved, we remove it from the list.
            // Loop until all XAttributes are resolved and removed from the list.
            while (nsAttributes.Any())
            {
                // Inner loop repeats until no XAttributes can be resolved without dealing with conflicting
                // prefixes (i.e. same prefix refers to different namespace in different XElements)
                while (nsAttributes.Any())
                {
                    // Loop through each XAttribute
                    foreach (var attr in nsAttributes.ToList())
                    {
                        // If the root already contains a declaration of the same namespace
                        // (regardless of whether the prefix matches between the root and the descendant)
                        if (xRoot.Attributes().Any(a => a.Value == attr.Value))
                        {
                            // We have only to remove the XAttribute from the descendant, and Xml.Linq
                            // framework automatically rectifies prefix on the descendant if necessary.
                            TransferNamespaceToRoot(nsAttributes, xRoot, null, attr,
                                                        valueChangingAttribNames);
                        }
                    }
                    // Take the first remaining prefix group where there is no prefix name conflict
                    var prefixGroup = prefixGroups
                              .FirstOrDefault(g => g.Select(a => a.Value).Distinct().Count() == 1);
                    // If no such groups remain, then we're done with the inner loop
                    if (prefixGroup == null) break;
                    // The list of XAttributes that have matching prefix & namespace
                    var attribs = prefixGroup.ToList();
                    for (int j = 0; j < attribs.Count; j++)
                        // The first XAttribute must be added to the root, and the rest simply need
                        // to be removed from the descendant.
                        TransferNamespaceToRoot(nsAttributes, xRoot,
                                     (j == 0 ? attribs[j] : null), attribs[j], valueChangingAttribNames);
                }
                // Take the first remaining prefix group. We know there is a prefix name conflict since
                // this group was not processed in the above loop.
                var conflictGroup = prefixGroups.FirstOrDefault();
                if (conflictGroup == null) break;
                // The processing of the previous loop should guarantee that all namespaces in
                // this group are not yet declared in the root.  Each of the conflicting prefixes
                // must be renamed.  If we try to add the existing prefix to the root for any one
                // of the namespaces in this group, then the Xml.Linq framework will incorrectly match
                // the other prefixes in this group to that namespace.
                foreach (var attr in conflictGroup.ToList())
                {
                    // If the root already contains a declaration of the same namespace
                    // (could only be a previously-processed XAttribute from this same conflict group)
                    if (xRoot.Attributes().Any(a => a.Value == attr.Value))
                    {
                        // We have only to remove the XAttribute from the descendant, and Xml.Linq
                        // framework automatically rectifies prefix on the descendant if necessary.
                        TransferNamespaceToRoot(nsAttributes, xRoot, null, attr, valueChangingAttribNames);
                        continue;
                    }
                    // Find a new prefix that doesn't conflict with any existing prefixes
                    String newPrefix = attr.Name.LocalName + "_A";
                    for (int i = 1; xRoot.Attributes().Any(a => a.Name.LocalName == newPrefix); i++)
                        newPrefix = attr.Name.LocalName + "_" + letters[i];
                    // Add the namespace declaration to the root, using the new prefix
                    XNamespace ns = attr.Value;
                    var newAttr = new XAttribute(XNamespace.Xmlns + newPrefix, attr.Value);
                    TransferNamespaceToRoot(nsAttributes, xRoot, newAttr, attr, valueChangingAttribNames);
                }
            }
        }
        /// <summary>
        /// This private method is designed as a helper to public method ConsolidateNamespaces.
        /// The method is designed to remove a given XAttribute from a descendant XElement,
        /// and add a given XAttribute to the root XElement.  The XAttribute to add to the root
        /// may be the same as the item to remove, different than the item to remove, or none,
        /// as appropriate.
        /// </summary>
        /// <param name="nsAttributes">The list of XAttributes that the caller is to process.
        /// This method is designed to remove 'attrToRemove' from the list.</param>
        /// <param name="xRoot">The root XElement to which 'attrToAdd' is added.</param>
        /// <param name="attrToAdd">The XAttribute that is to be added to 'xRoot'.  This may be
        /// the same as or different than 'attrToRemove', or it may be null if the caller does
        /// not need to add anything to the root.</param>
        /// <param name="attrToRemove">The XAttribute that is to be removed from a descendant XElement
        /// and removed from 'nsAttributes'</param>
        /// <param name="valueChangingAttribNames">A list of the names of XAttributes whose value
        /// must be updated to reflect changes to the namespace prefixes.
        /// This is designed to handle cases like d7p1 in the example:
        ///     xmlns:d7p1="http://www.w3.org/2001/XMLSchema" i:type="d7p1:int"
        /// generated by System.Runtime.Serialization.DataContractSerializer. In order to treat this
        /// example, the XName of the i:type attribute should be included in the list.  If the value
        /// of the 'valueChangingAttribNames' parameter is null, then no such changes are made to the
        /// values of XAttributes.  The default is null.
        /// </param>
        private static void TransferNamespaceToRoot(List<XAttribute> nsAttributes, XElement xRoot,
                                XAttribute attrToAdd, XAttribute attrToRemove,
                                List<XName> valueChangingAttribNames)
        {
            if (valueChangingAttribNames != null)
            {
                // Change the value of any 'value changing attributes' that incorporate the prefix.
                // This is designed to handle cases like d7p1 in the example:
                //     <d2p1:Value xmlns:d7p1="http://www.w3.org/2001/XMLSchema" i:type="d7p1:int">
                // that are generated by System.Runtime.Serialization.DataContractSerializer.
                // The Xml.Linq framework does not rectify such cases where the prefix is
                // within the XAttribute vaue.
                String oldPrefix = attrToRemove.Name.LocalName;
                String newPrefix = oldPrefix;
                // If no XAttribute is to be added to the root
                if (attrToAdd == null)
                {
                    // find the existing XAttribute in the root for the namespace,
                    // and use the prefix that it declares.
                    var srcAttr = xRoot.Attributes()
                            .FirstOrDefault(a => a.IsNamespaceDeclaration && a.Value == attrToRemove.Value);
                    if (srcAttr != null)
                        newPrefix = srcAttr.Name.LocalName;
                }
                else
                    // If a new XAttribute is to be added to the root, then use the prefix it declares
                    newPrefix = attrToAdd.Name.LocalName;
                if (oldPrefix != newPrefix)
                {
                    foreach (XName attribName in valueChangingAttribNames)
                    {
                        // Do string replacement of the prefix in the XAttribute value
                        var vcAttrib = attrToRemove.Parent.Attribute(attribName);
                        vcAttrib.Value = vcAttrib.Value.Replace(attrToRemove.Name.LocalName, newPrefix);
                    }
                }
            }
            // Add the XAttribute to the root element
            if (attrToAdd != null)
                xRoot.Add(attrToAdd);
            // Remove the namespace declaration from the descendant
            attrToRemove.Remove();
            // remove the XAttribute from the list of XAttributes to be processed
            nsAttributes.Remove(attrToRemove);
        }
