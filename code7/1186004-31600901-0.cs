    public
    abstract    class   InputSource
    { 
        public      InputSource<T>  As<T>()     { return (InputSource<T>) this; }
        protected
        abstract    Object          getValue();
        public      Object          GetValue()  { return this.getValue(); }
        
    }
    public      class   InputSource<T> : InputSource
    {
        public
        override    object  getValue()  { return this.GetValue(); }
        public
        new         T       GetValue()  { /* do something interesting here */ throw new NotImplementedException(); }
        
    }
    public void update(IList<InputSource> inputs)
    {
        inputs.Add(new InputSource<double>());
        inputs.Add(new InputSource<int>());
    }
