    public class Class1
    {
        private bool _isInnerInstance = false;
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
            set
            {
                if (_isInnerInstance && value == Flag.A)
                    throw new ArgumentException("innerFlag must not be Flag.A!", "innerFlag");
                _Flag = value;
            }
        }
        private Class1(Flag innerFlag)
        {
            this.Flag = innerFlag;
            _isInnerInstance = true;
            _Class1Prop = null; // or whatever
        }
        public Class1(Flag flag, Flag innerFlag)
        {
            if (innerFlag == Flag.A)
                throw new ArgumentException("innerFlag must not be Flag.A!", "innerFlag");
            this.Flag = flag;
            _Class1Prop = new Class1(innerFlag);
        }
    }
