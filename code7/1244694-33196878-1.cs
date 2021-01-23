    class Element
    {
        private bool _elemCanBeSet = false;
        private elemNum _elemType;
   
        public elemEnum ElemType
        {
            get { return _elemType; }
            set { if (_elemCanBeSet) _elemType = value; }
        }
        public double Amount {get; set;} // How many atoms of this type in the formula
        public void SetElemType(string type)
        {
            _elemCanBeSet = true;
            this.ElemType = (elemEnum)Enum.Parse(typeof(elemEnum), type);
            _elemCanBeSet = false;
        }
    }
