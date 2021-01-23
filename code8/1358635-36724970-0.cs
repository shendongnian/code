    class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                List<Company> companies = new List<Company>();
                var unique = companies.AsEnumerable().GroupBy(x => x.name)
                    .Where(x => x.Select(y => x.SelectMany(z => !z.email.Contains(y.email)) && x.SelectMany(z => z.addy.Contains(y.addy)).Select(a => z)).ToList();
            }
     
        }
        public class Company
        {
            public string name {get;set;}
            public string email {get;set;}
            public string addy {get;set;}
        }
