    public class HeaderTypeEnq<T> : HeaderType<T>
    {
        public string Mandatory { get; set; }
        public string CharacterType { get; set; }
        public string FixedLength { get; set; }
        public int Position { get; set; }
        public int MaxLength { get; set; }
        public int CharToRead
        {
            get
            {
                return Value.Length;
            }
        }
    }
