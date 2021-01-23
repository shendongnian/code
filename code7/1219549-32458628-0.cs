    public class TextComparer<T> : IComparer
    {
        private bool HasTextProperty(Type t)
        {
            return (t.GetProperty("Text", typeof(string)) != null);
        }
    
        private string GetTextPropertyValue(object obj)
        {
            return obj.GetType().GetProperty("Text", typeof(string)).GetValue(obj) as string;
        }
    
        public TextComparer()
        {
            if (!HasTextProperty(typeof(T))) throw new ArgumentException(string.Format("{0} doesn't provide a Text property", typeof(T).Name), "T");
        }
    
        public int Compare(object x, object y)
        {
            return GetTextPropertyValue(x).CompareTo(GetTextPropertyValue(y));
        }
    }
