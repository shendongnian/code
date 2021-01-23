    class Element
    {
        public ElemEnum ElemType {get; private set;}
        public double Amount {get; set;}
        public void SetElemType(string type)
        {
            this.ElemType = (ElemEnum)Enum.Parse(typeof(ElemEnum), type);
        }
    }
