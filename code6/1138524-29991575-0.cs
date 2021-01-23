        class yourEventArgs:EventArgs
    {
        public yourEventArgs(object yourValues)
        {
            Value = yourValues;
        }
        //Create your properties like below
        public object Value { get; set; }
    }
