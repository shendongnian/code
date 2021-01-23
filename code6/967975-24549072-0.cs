        [ComplexType]
    public class LocalizedString : IComparer, IComparable
    {
        
        public string EnglishText { get; set; }
        public string GermanText { get; set; }
        
        // this is only an example - the real class has some methods to return the text in the current language.
        public int Compare(object x, object y)
        {
            throw new NotImplementedException();
        }
        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
        public string GetText()
        {
            if (DateTime.Now.Second%2 == 0)
                return EnglishText;
            else
                return GermanText;
        }
        public void SetText(string value)
        {
            if (DateTime.Now.Second%2 == 0)
                EnglishText = value;
            else
                GermanText = value;
        }
    }
