    public class myDataSource
    {
        public BindingList<myData> MyDataSourceList
        {
            get
            {
                var list = new List<myData>()
                {
                    new myData() { ColA = "A" },
                    new myData() { ColA = "B" }
                };
    
                return new BindingList<myData>(list);
            }
        }
    }
    
    public class myData
    {
        public string ColA { set; get; }
    }
