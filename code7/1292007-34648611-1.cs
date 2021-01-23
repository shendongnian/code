    public class JSObj
    {
        public string Title { get; set; }
        public int UpperVal { get; set; }
        public int LowerVal { get; set; }
        public object MouseOver
        {
            get
            {
                // use JRaw to set the value of the anonymous function
                return new JRaw(string.Format(@"function(){{ return {0}; }}", UpperVal - LowerVal));
            }
        }
    }
    
    // and then serialize using the JsonConvert class
    var obj = new JSObj { Title = "Test", LowerVal = 4, UpperVal = 10 };
    var jsonObj = JsonConvert.SerializeObject(obj);
