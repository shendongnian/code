    public class MyClass
    {
        public string CstCmpCode { get; set; }
        public string Loaded_date { get; set; }
        public string Main_Group { get; set; }
        public Result[] results { get; set; }
    }
    
    public class Result
    {
        public string Sub_Group { get; set; }
        public int ClosBal { get; set; }
    }
