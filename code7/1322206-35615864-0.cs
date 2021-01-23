    public void SetXDocument(string name)
    {
         if(_xDoc == null)
            _xDoc = GetXDocument(value);
    }
    // usage
    myClass.SetXDocument("Name of XML File");
