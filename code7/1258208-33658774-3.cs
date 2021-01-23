    public static class XmlPremOutHelper
    {
        public static void GroupPremiumElements(TextReader from, TextWriter to)
        {
            var doc = XDocument.Load(from);
            foreach (var node in doc.Descendants("PREMout"))
            {
                var lists = new[] { 
                    node.Elements("PremFromDate").ToList(),
                    node.Elements("PremToDate").ToList(),
                    node.Elements("AnnualPremium").ToList(),
                    node.Elements("ModePremium").ToList(),
                };
                if (!lists.Skip(1).All(l => l.Count == lists[0].Count))
                    throw new InvalidOperationException("Unequal list counts");
                foreach (var nodes in lists.ZipMany(l => l))
                {
                    nodes.Remove();
                    node.Add(new XElement("PREMoutData", nodes));
                }
            }
            doc.Save(to);
        }
    }
    public static class EnumerableExtensions
    {
        // Taken from
        // https://stackoverflow.com/questions/17976823/how-to-zip-or-rotate-a-variable-number-of-lists
        public static IEnumerable<TResult> ZipMany<TSource, TResult>(
            this IEnumerable<IEnumerable<TSource>> source,
            Func<IEnumerable<TSource>, TResult> selector)
        {
            // ToList is necessary to avoid deferred execution
            var enumerators = source.Select(seq => seq.GetEnumerator()).ToList();
            try
            {
                while (true)
                {
                    foreach (var e in enumerators)
                    {
                        bool b = e.MoveNext();
                        if (!b)
                            yield break;
                    }
                    // Again, ToList (or ToArray) is necessary to avoid deferred execution
                    yield return selector(enumerators.Select(e => e.Current).ToList());
                }
            }
            finally
            {
                foreach (var e in enumerators)
                    e.Dispose();
            }
        }
    }
