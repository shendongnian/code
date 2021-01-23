    class YourViewModel()
    {
        public object Table1 {get; set;}
        public object Table2 {get; set;}
    
        YourViewModel(dynamic LINQResult)
        {
            this.Table1 = LINQResult.prop1;
            this.Table2 = LINQResult.prop2;
        }
    }
