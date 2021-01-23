        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                List<Company> companies = new List<Company>();
                var groups = companies.AsEnumerable().GroupBy(x => x.name)
                    .Select(x => x.Where(y => (x.Select(z => z.email).ToList().Where(s => s == y.email).Count() == 1) && (x.Select(z => z.addy).ToList().Where(s => s == y.addy).Count() == 1)).Select(a => a)).SelectMany(b => b).ToList();
            }
     
        }
        public class Company
        {
            public string name {get;set;}
            public string email {get;set;}
            public string addy {get;set;}
        }
