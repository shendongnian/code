    public class test
    {
        public string name;
        public string lastname;
    }
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<test>
            {
                new test{name = "john", lastname = "smith"}
            };
            string fname = "aa";
            string lname = "sm";
            var select = list.Select(c=>c);
            if (fname != null)
                select = select.Where(c => c.name.Contains(fname));
            if (lname != null)
                select = select.Where(c => c.lastname.Contains(lname));
            var result = select.ToList();
        }
    }
