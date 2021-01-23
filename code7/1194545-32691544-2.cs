    public class MyType
    {
        public string  Text { get; set; }
        public string  SomethingEsle { get; set; }
    }
    public class Program
    {
        private static void Main(string[] args)
        {
            List<MyType> ojb = new List<MyType>();
            ojb.Add(new MyType {Text = "OMG", SomethingEsle = "cat"});
            //dynX is a dynamic...
            var dynX = ojb.Select(x => new {x.Text, x.SomethingEsle}).ToList();
            //NB this is the System.Linq.Select
            //this now works as the complier can determine that there is a property Text
            var result = dynX.Select(x => x.Text).ToList();
        }
    }
