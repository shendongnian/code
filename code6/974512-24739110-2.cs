    public class CommaSeparatedStringEnumerator : IEnumerator<string>
    {
        int previousComma = -1;
        int currentComma = -1;
        string bigString = null;
        bool atEnd = false;
        public CommaSeparatedStringEnumerator(string s)
        {
            if (s == null)
                throw new ArgumentNullException("s");
            bigString = s;
            this.Reset();
        }
        public string Current { get; private set; }
        public void Dispose() { /* No need to do anything here */ }
        object IEnumerator.Current { get { return this.Current; } }
        public bool MoveNext()
        {
            if (atEnd)
                return false;
            atEnd = (currentComma = bigString.IndexOf(',', previousComma + 1)) == -1;
            if (!atEnd)
                Current = bigString.Substring(previousComma + 1, currentComma - previousComma - 1);
            else
                Current = bigString.Substring(previousComma + 1);
            previousComma = currentComma;
            return true;
        }
        public void Reset()
        {
            previousComma = -1;
            currentComma = -1;
            atEnd = false;
            this.Current = null;
        }
    }
    public class CommaSeparatedStringEnumerable : IEnumerable<string>
    {
        string bigString = null;
        public CommaSeparatedStringEnumerable(string s)
        {
            if (s == null)
                throw new ArgumentNullException("s");
            bigString = s;
        }
        public IEnumerator<string> GetEnumerator()
        {
            return new CommaSeparatedStringEnumerator(bigString);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
