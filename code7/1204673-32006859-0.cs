    class PassValue : AbstractConstraint
    {
        public Poco Obj { get; private set; }
        public override bool Eval(object obj)
        {
            Obj = (Poco)obj;
            return true;
        }
        public override string Message
        {
            get { throw new NotImplementedException(); }
        }
    }
