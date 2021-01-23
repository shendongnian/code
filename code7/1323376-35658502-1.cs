    public class MyModel
    {
        [MultipleRegExAttribute2(@"[^?.]{1,100}$")]
        [MultipleRegExAttribute3(@"^((?![><&])[\s\S])*$")]
        public string Name { get; set; }
    }
   
    public class MultipleRegExAttribute2 : RegularExpressionAttribute
    {
        public MultipleRegExAttribute2(string pattern) : base(pattern) { }
    }
    public class MultipleRegExAttribute3 : RegularExpressionAttribute
    {
        public MultipleRegExAttribute3(string pattern) : base(pattern) { }
    }
