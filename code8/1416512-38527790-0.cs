     >     "meta": []
    For some reason (possibly a bug?) these confuse the converter causing it to throw an exception.  However, since they are empty, they can be removed and ignored:
        public static void RemoveEmptyArrayProperties(JContainer root)
        {
            var query = root.DescendantsAndSelf()
                .OfType<JProperty>()
                .Where(p => p.Value is JArray && ((JArray)p.Value).Count == 0);
            foreach (var property in query.ToList())
            {
                property.Remove();
            }
        }
