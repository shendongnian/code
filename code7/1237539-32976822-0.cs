    public class CompanyRegistrationModel
    {
        public string FieldValue { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Industry { get; set; }
        public string Rank { get; set; }
        public CompanyRegistrationModel Get()
        {
            using (TablesContext tc = new TablesContext())
            {
                
            var comps = (from c in tc.companies
                join r in tc.registry
                    on c.Key equals r.Key
                select
                    new CompanyRegistrationModel
                    {
                        FieldValue = r.FieldValue,
                        Name = c.Name,
                        Company = c.Company,
                        Industry = c.Industry,
                        Rank = c.Rank
                    }).ToList();
            return comps;
            }
        }
    }
