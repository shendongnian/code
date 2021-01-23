    class YourViewModel()
    {
        public object propertyOfTable1 {get; set;}
        public object propertyOfTable2 {get; set;}
    
        YourViewModel(dynamic linqEntity)
        {
            this.propertyOfTable1 = linqEntity.prop1;
            this.propertyOfTable2 = linqEntity.prop2;
        }
    }
