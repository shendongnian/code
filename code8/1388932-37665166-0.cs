    public static class XNodeExtensions
    {
        /// <summary>
        /// Flatten a two-level collection with an outer container element to a one-level collection 
        /// in preparation for conversion to JSON using Json.NET
        /// </summary>
        /// <param name="parents">The outer container elements.</param>
        /// <param name="childName">The inner element name.  If null, flatten all children.</param>
        /// <param name="newChildName">The new element name.  If null, use the parent name.</param>
        public static void FlattenCollection(this IEnumerable<XElement> parents, XName childName = null, XName newChildName = null)
        {
            if (parents == null)
                throw new ArgumentNullException();
            XNamespace json = @"http://james.newtonking.com/projects/json";
            XName isArray = json + "Array";
            foreach (var parent in parents.ToList())
            {
                if (parent.Parent == null)
                    continue; // Removed or root
                foreach (var child in (childName == null ? parent.Elements() : parent.Elements(childName)).ToList())
                {
                    child.Remove();
                    child.Name = newChildName ?? parent.Name;
                    child.Add(new XAttribute(isArray, true));
                    parent.Parent.Add(child);
                }
                if (!parent.HasElements)
                    parent.Remove();
            }
        }
    }
