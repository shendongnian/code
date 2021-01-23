    class MyElemSetter
    {
        private readonly elemEnum elem;
        public MyElemSetter(elemEnum e, Action helperAction)
	    {
            MethodInfo callingMethodInfo = helperAction.Method;
            if (helperAction.Method.Name.Contains("<SetElemType>")) elem = e;
	    }
        public static implicit operator elemEnum(MyElemSetter e)
        {
            return e.elem;
        }
    }
    class Element
    {
        private MyElemSetter _elemType;
        public elemEnum ElemType { get { return _elemType; } }
        public void SetElemType(string type)
        {
            this._elemType = new MyElemSetter((elemEnum)Enum.Parse(typeof(elemEnum), type), () => { });
        }
        public double Amount { get; set; } // How many atoms of this type in the formula
    }
