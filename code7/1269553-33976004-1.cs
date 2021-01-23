    public class cA
    {
        protected IEnumerable<Object> MyData { get; set; }
        
        public bool Find(args)
        {
            // Do stuff with MyData
        }
    }
    public class cB : cA
    {
        protected new IEnumerable<MyOtherDataType> MyData { get; set; }
    }
