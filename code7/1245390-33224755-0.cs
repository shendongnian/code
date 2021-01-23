    public class s
    {
        public string s1 { get; set; }
    }
    
    public class s2
    {
        public s s3 { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            s2 objs2 = new s2();
            s2.s3 = new s();
            objs2.s3.s1 = "asdf";
        }
    }
