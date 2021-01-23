    public class ThereIsDataSourceInThisClass
    {
        public ThereIsDataSourceInThisClass()
        {
            MyDataSource = new BindingList<Thing>();
            MyDataSource.Add(new Thing { First = "aa", Second = "bb" });
        }
        public BindingList<Thing> MyDataSource { get; set; }
        public class Thing
        {
            public string First { get; set; }
            public string Second { get; set; }
        }
    }
