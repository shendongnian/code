    public enum Flag
    {
        A, B, C, D
    }
    public class Class1
    {
        private Class1 _Class1Inner;
        public Class1 Class1Inner
        {
            get { return _Class1Inner; }
            private set { _Class1Inner = value; }
        }
        private Flag _Flag;
        public Flag Flag
        {
            get { return _Flag; }
            private set { _Flag = value; }
        }
        // used only to create the inner instance
        private Class1(Flag innerFlag)
        {
            this.Flag = innerFlag;
            _Class1Inner = null; // or whatever 
        }
        public Class1(Flag flag, Flag innerFlag)
        {
            if (innerFlag == Flag.A)
                throw new ArgumentException("innerFlag must not be Flag.A!", "innerFlag");
            this.Flag = flag;
            this.Class1Inner= new Class1(innerFlag);
        }
    }
