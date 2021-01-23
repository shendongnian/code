    class MyDataTable : DataTable
    {
        public MyDataTable()
        {
            this.Columns.Add("col1");
            this.Columns.Add("col2");        
            this.Columns.Add("Cat", typeof(Cat));
            // notice the typeof here
            this.Columns.Add("CatType", typeof(LiveString));
    
            Cat cat1 = new Cat("name1", "type1");
            Cat cat2 = new Cat("name2", "type2");
            this.Rows.Add(new object[] {"value","value",cat1,cat1.type} );
            this.Rows.Add(new object[] {"value","value",cat2,cat2.type} );
    
            cat1.type = "type3"; 
        }
    } 
