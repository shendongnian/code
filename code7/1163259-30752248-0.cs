    public enum Flag
    {
        A, B, C, D
    }
    public class Class1
    {
        private Class1 _Class1Prop;
        public Class1 Class1Prop
        {
            get { return _Class1Prop; }
            private set { _Class1Prop = value; }
        }
        private Flag _Flag;
        public Flag Flag
        {
            get { return _Flag; }
            private set { _Flag = value; }
        }
        public Class1(Flag flag, Flag innerFlag = Flag.B)
        {
            if (innerFlag == Flag.A)
                throw new ArgumentException("innerFlag must not be Flag.A!", "innerFlag");
            this.Flag = flag;
            _Class1Prop = new Class1(innerFlag, innerFlag);
        }
    }
