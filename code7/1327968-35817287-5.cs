    public class XmlKeyTextValueListWrapper<TValue> : CollectionWrapper<KeyValuePair<string, TValue>>, IXmlSerializable
    {
        public XmlKeyTextValueListWrapper() : base(new List<KeyValuePair<string, TValue>>()) { } // For deserialization.
        public XmlKeyTextValueListWrapper(ICollection<KeyValuePair<string, TValue>> baseCollection) : base(baseCollection) { }
        public XmlKeyTextValueListWrapper(Func<ICollection<KeyValuePair<string, TValue>>> getCollection) : base(getCollection) {}
        #region IXmlSerializable Members
        public XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
            var converter = TypeDescriptor.GetConverter(typeof(TValue));
            XmlKeyValueListHelper.ReadXml(reader, this, converter);
        }
        public void WriteXml(XmlWriter writer)
        {
            var converter = TypeDescriptor.GetConverter(typeof(TValue));
            XmlKeyValueListHelper.WriteXml(writer, this, converter);
        }
        #endregion
    }
    public static class XmlKeyValueListHelper
    {
        public static void WriteXml<T>(XmlWriter writer, ICollection<KeyValuePair<string, T>> collection, TypeConverter typeConverter)
        {
            foreach (var pair in collection)
            {
                writer.WriteStartElement(XmlConvert.EncodeName(pair.Key));
                writer.WriteValue(typeConverter.ConvertToInvariantString(pair.Value));
                writer.WriteEndElement();
            }
        }
        public static void ReadXml<T>(XmlReader reader, ICollection<KeyValuePair<string, T>> collection, TypeConverter typeConverter)
        {
            if (reader.IsEmptyElement)
            {
                reader.Read();
                return;
            }
            reader.ReadStartElement(); // Advance to the first sub element of the list element.
            while (reader.NodeType == XmlNodeType.Element)
            {
                var key = XmlConvert.DecodeName(reader.Name);
                string value;
                if (reader.IsEmptyElement)
                {
                    value = string.Empty;
                    // Move past the end of item element
                    reader.Read();
                }
                else
                {
                    // Read content and move past the end of item element
                    value = reader.ReadElementContentAsString();
                }
                collection.Add(new KeyValuePair<string,T>(key, (T)typeConverter.ConvertFromInvariantString(value)));
            }
            // Move past the end of the list element
            reader.ReadEndElement();
        }
        public static void CopyTo<TValue>(this XmlKeyTextValueListWrapper<TValue> collection, ICollection<KeyValuePair<string, TValue>> dictionary)
        {
            if (dictionary == null)
                throw new ArgumentNullException("dictionary");
            if (collection == null)
                dictionary.Clear();
            else
            {
                if (collection.IsWrapperFor(dictionary)) // For efficiency
                    return;
                var pairs = collection.ToList();
                dictionary.Clear();
                foreach (var item in pairs)
                    dictionary.Add(item);
            }
        }
    }
    public class CollectionWrapper<T> : ICollection<T>
    {
        readonly Func<ICollection<T>> getCollection;
        public CollectionWrapper(ICollection<T> baseCollection)
        {
            if (baseCollection == null)
                throw new ArgumentNullException();
            this.getCollection = () => baseCollection;
        }
        public CollectionWrapper(Func<ICollection<T>> getCollection)
        {
            if (getCollection == null)
                throw new ArgumentNullException();
            this.getCollection = getCollection;
        }
        public bool IsWrapperFor(ICollection<T> other)
        {
            if (other == Collection)
                return true;
            var otherWrapper = other as CollectionWrapper<T>;
            return otherWrapper != null && otherWrapper.IsWrapperFor(Collection);
        }
        ICollection<T> Collection { get { return getCollection(); } }
        #region ICollection<T> Members
        public void Add(T item)
        {
            Collection.Add(item);
        }
        public void Clear()
        {
            Collection.Clear();
        }
        public bool Contains(T item)
        {
            return Collection.Contains(item);
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            Collection.CopyTo(array, arrayIndex);
        }
        public int Count
        {
            get { return Collection.Count; }
        }
        public bool IsReadOnly
        {
            get { return Collection.IsReadOnly; }
        }
        public bool Remove(T item)
        {
            return Collection.Remove(item);
        }
        #endregion
        #region IEnumerable<T> Members
        public IEnumerator<T> GetEnumerator()
        {
            return Collection.GetEnumerator();
        }
        #endregion
        #region IEnumerable Members
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
