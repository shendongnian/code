    public class MyCustomEnumerator : IEnumerator<YouRecordType>
    {
        private readonly string _fileName;
        private int _index;
        YouRecordType _current;
        public MyCustomEnumerator(string fileName)
        {
            _fileName = fileName;
            //open COM object here
        }
        public void Dispose()
        {
            //Dispose used COM resources.
        }
        public bool MoveNext()
        {
            //Read next row from the COM object
            var couldReadAnotherRow = true;
            _current = null; //comObject.Read(_index++); 
            return couldReadAnotherRow;
        }
        public void Reset()
        {
            //want to start over
        }
        public YouRecordType Current { get { return _current; } }
        object IEnumerator.Current
        {
            get { return Current; }
        }
    }
