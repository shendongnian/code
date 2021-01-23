        public static void RemovedNamedAttributes(XElement root, string attributeLocalNamePrefix)
        {
            if (root == null)
                throw new ArgumentNullException();
            foreach (var node in root.DescendantsAndSelf())
                node.Attributes().Where(a => a.Name.LocalName == attributeLocalNamePrefix).Remove();
        }
