    public class ApplicationAddress
    {
        private readonly string[] _array = new string[2];
        public string this[int index]
        {
            get { return _array[index]; }
            set { _array[index] = value; }
        }
        public string addreesLine1
        {
            get { return this[0]; }
            set { this[0] = value; }
        }
        public string addreesLine2
        {
            get { return this[1]; }
            set { this[1] = value; }
        }
    }
