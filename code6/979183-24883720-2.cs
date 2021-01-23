    public class StringBuilderList : IList<string>
    {
        readonly List<StringBuilder> list = new List<StringBuilder>();
        readonly char pad = ' ';
        const char DefaultPad = ' ';
        public StringBuilderList(char pad)
        {
            this.pad = pad;
        }
        public StringBuilderList() : this(DefaultPad) {}
        public void SetString(int iLine, int iChar, string text)
        {
            list.EnsureCount(iLine + 1);
            if (list[iLine] == null)
                list[iLine] = new StringBuilder(iChar + text.Length);
            var sb = list[iLine];
            sb.OverwriteAt(iChar, text, pad);
        }
        #region IList<string> Members
        public int IndexOf(string item)
        {
            for (int i = 0; i < Count; i++)
                if (this[i] == item) // this is not memory-efficient.
                    return i;
            return -1;
        }
        public void Insert(int index, string item)
        {
            var sb = new StringBuilder(item);
            list.Insert(index, sb);
        }
        public void RemoveAt(int index)
        {
            list.RemoveAt(index);
        }
        public string this[int index]
        {
            get
            {
                // Hide the nulls from the caller!
                var sb = list[index];
                if (sb == null)
                    return string.Empty;
                return sb.ToString();
            }
            set
            {
                list[index].Length = 0;
                list[index].Append(value);
            }
        }
        #endregion
        #region ICollection<string> Members
        public void Add(string item)
        {
            list.Add(new StringBuilder(item));
        }
        public void Clear()
        {
            list.Clear();
        }
        public bool Contains(string item)
        {
            return IndexOf(item) >= 0;
        }
        public void CopyTo(string[] array, int arrayIndex)
        {
            foreach (var str in this)
                array[arrayIndex++] = str;
        }
        public int Count
        {
            get { return list.Count; }
        }
        public bool IsReadOnly
        {
            get { return false; }
        }
        public bool Remove(string item)
        {
            int index = IndexOf(item);
            if (index < 0)
                return false;
            RemoveAt(index);
            return true;
        }
        #endregion
        #region IEnumerable<string> Members
        public IEnumerator<string> GetEnumerator()
        {
            foreach (var sb in list)
                yield return (sb == null ? string.Empty : sb.ToString());
        }
        #endregion
        #region IEnumerable Members
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
