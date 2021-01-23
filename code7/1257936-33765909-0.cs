    public class MyCustomCollection : IEnumerable<YouRecordType>
    {
        private readonly string _fileName;
        public MyCustomCollection(string fileName)
        {
            if (fileName == null) throw new ArgumentNullException(nameof(fileName));
            _fileName = fileName;
        }
        public IEnumerator<YouRecordType> GetEnumerator()
        {
            return new MyCustomEnumerator(_fileName);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
