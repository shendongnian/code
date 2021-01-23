    class Program
    {
        static void Main(string[] args)
        {
            var companies = new List<Company> 
                                {new Company {Name = "company1", Location = "location1"},
                                 new Company {Name = "company2", Location = "location1"},
                                 new Company {Name = "company1", Location = "location2"},
                                 new Company {Name = "company3", Location = "location1"},
                                 new Company {Name = "company2", Location = "location2"},
                                 new Company {Name = "company1", Location = "location3"},
                                 new Company {Name = "company1", Location = "location4"}};
            var locations = new List<IP>
                                {new IP {Name = "ip1", Location = "location1"},
                                 new IP {Name = "ip1", Location = "location2"},
                                 new IP {Name = "ip2", Location = "location3"},
                                 new IP {Name = "ip3", Location = "location4"}};
            var query = locations.Join(companies, 
                                       ip => ip.Location, 
                                       c => c.Location, 
                                       (ip, c) => new JoinResult() { IP = ip, 
                                                                     Company = c });
            foreach (var result in query)
            {
                Console.WriteLine("IP: {0} - {1}, Company: {2}", 
                                  result.IP.Name, 
                                  result.IP.Location, 
                                  result.Company.Name);
            }
            Console.ReadKey();
        }
        public class Company
        {
            public string Name;
            public string Location;
        }
        public class IP
        {
            public string Name;
            public string Location;
        }
        public class JoinResult
        {
            public Company Company;
            public IP IP;
        }
    }
