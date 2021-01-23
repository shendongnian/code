    public class XDocumentRepository
    {
        readonly XDocument doc;
        readonly Dictionary<XName, List<XElement>> elementsByName = new Dictionary<XName, List<XElement>>();
        public XDocument Document { get { return doc; } }
        public IEnumerable<XElement> ElementsByName(XName name)
        {
            return elementsByName.Items(name);
        }
        public XDocumentRepository(XDocument doc)
        {
            if (doc == null)
                throw new ArgumentNullException();
            this.doc = doc;
            doc.Changing += new EventHandler<XObjectChangeEventArgs>(doc_Changing);
            doc.Changed += new EventHandler<XObjectChangeEventArgs>(doc_Changed);
            foreach (var element in doc.Root.DescendantsAndSelf())
                elementsByName.AddItem(element.Name, element);
        }
        void doc_Changed(object sender, XObjectChangeEventArgs e)
        {
            XElement xSender = sender as XElement;
            if (xSender != null && xSender.Document == doc)
            {
                elementsByName.AddItem(xSender.Name, xSender);
            }
            // If an attribute value were changed, sender would be an XAttribute
        }
        void doc_Changing(object sender, XObjectChangeEventArgs e)
        {
            XElement xSender = sender as XElement;
            if (xSender != null)
            {
                elementsByName.RemoveItem(xSender.Name, xSender);
            }
            // If an attribute value were changed, sender would be an XAttribute
        }
    }
    public static class DictionaryExtensions
    {
        public static void AddItem<TKey, TValueList, TValue>(this IDictionary<TKey, TValueList> listDictionary, TKey key, TValue value)
            where TValueList : IList<TValue>, new()
        {
            if (listDictionary == null)
                throw new ArgumentNullException();
            TValueList values;
            if (!listDictionary.TryGetValue(key, out values))
                listDictionary[key] = values = new TValueList();
            values.Add(value);
        }
        public static IEnumerable<TValue> Items<TKey, TValue>(this IDictionary<TKey, List<TValue>> listDictionary, TKey key)
        {
            if (listDictionary == null)
                throw new ArgumentNullException();
            List<TValue> list;
            if (!listDictionary.TryGetValue(key, out list))
                return Enumerable.Empty<TValue>();
            return list;
        }
        public static bool RemoveItem<TKey, TValueList, TValue>(this IDictionary<TKey, TValueList> listDictionary, TKey key, TValue value)
            where TValueList : IList<TValue>, new()
        {
            if (listDictionary == null)
                throw new ArgumentNullException();
            TValueList values;
            if (!listDictionary.TryGetValue(key, out values))
                return false;
            return values.Remove(value);
        }
    }
