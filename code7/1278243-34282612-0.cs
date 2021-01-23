    public class MyClass
    {
        private bool readOnly;
        private int x;
        public int X
        {
            get { return x; }
            set
            {
                if (readOnly) throw new InvalidOperationException();
                else x = value;
            }
        }
        public MyClass()
        {
            X = 42;
            readOnly = true;
        }
    }
