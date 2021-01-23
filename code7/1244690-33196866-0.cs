    class Element
    {
       private elemNum _elemType;
       public elemEnum ElemType { get { return _elemType; } }
       public void SetElemType(string type) 
       {
          this._elemType = (elemEnum)Enum.Parse(typeof(elemEnum), type);
       }
       public double Amount {get; } // How many atoms of this type in the formula
    }
