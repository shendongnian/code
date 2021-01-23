        /// <summary>
        /// This method finds all namespace declarations on the descendants of the given root XElement
        /// and moves them from the decendant elements to the root element. It is thus possible to 
        /// make the XML string much smaller and more human-readable in cases when there are many
        /// redundant declarations of the same namespace.
        /// </summary>
        /// <param name="xRoot">The element whose descendants are to have their namespaces declarations
        /// removed.  Also, the element that is to contain the consolidated namespace declarations</param>
        public static void ConsolidateNamespaces(this XElement xRoot)
        {
            String letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            // Find all XAttributes that represent namespace declarations
            var nsAttributes = xRoot.Descendants().SelectMany(e => e.Attributes())
                        .Where(a => a.IsNamespaceDeclaration).ToList();
            // Loop through each XAttribute
            foreach (var attr in nsAttributes)
            {
                // If the root already contains a declaration of the same namespace
                // (regardless of whether the prefix matches between the root and the descendant)
                if (xRoot.Attributes().Any(a => a.Value == attr.Value))
                {
                    // We have only to remove the XAttribute from the descendant,
                    // and the prefixes will be automatically rectified if necessary
                    attr.Remove();
                    continue;
                }
                // If the root already contains a declaration with the same prefix,
                // but for a different namespace
                if (xRoot.Attributes().Any(a => a.Name.LocalName == attr.Name.LocalName))
                {
                    // Find a new prefix that does't conflict with any existing prefixes
                    String newPrefix = attr.Name.LocalName + "_A";
                    for (int i = 1; xRoot.Attributes().Any(a => a.Name.LocalName == newPrefix); i++)
                        newPrefix = attr.Name.LocalName + "_" + letters[i];
                    // Add a namespace declaration to the root, using the new prefix
                    XNamespace ns = attr.Value;
                    var newAttr = new XAttribute(XNamespace.Xmlns + newPrefix, attr.Value);
                    xRoot.Add(newAttr);
                    // Remove the namespace declaration from the descendant
                    attr.Remove();
                    continue;
                }
                // If neither of the above overlapping situations was found,
                // then just add the namespace declaration to the root
                xRoot.Add(attr);
                // and remove it from the descendant
                attr.Remove();
            }
        }
