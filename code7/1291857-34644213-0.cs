    public class Program
    {
        public static void Main(string[] args)
        {
            var orgs = new List<string>();
            var orgClass = new Organizations(orgs);
            orgClass.TestAdd();
            Console.WriteLine(orgs.First());
            Console.Read();
        }
    }
    public class Organizations
    {
        private ICollection<string> _orgs;
        public Organizations(ICollection<string> orgs)
        {
            _orgs = orgs;
        }
        public void TestAdd()
        {
            _orgs.Add("Testing 123");
        }
    }
    //Output: "Testing 123"
