    class A
    {
        public string Data
        {
            get{return "A";}
        }
        public virtual string VData
        {
            get{return "A";}
        }
    }
    class B:A
    {
        public new string Data
        {
            get{return "B";}
        }
        public override string VData
        {
            get{return "B";}
        }
    }
