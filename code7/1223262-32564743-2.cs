    using System;
    using System.Collections;
    using System.Collections.Generic;
    
    namespace Tests
    {
        class Test
        {
            static void Main(string[] args)
            {
                var company = new Company
                {
                    companyId = 1,
                    name = "ACME",
                };
                company.asns = new List<Asn>
                {
                    new Asn { asnId = 1, companyId = company.companyId, company = company  },
                    new Asn { asnId = 2, companyId = company.companyId, company = company  },
                };
                company.contacts = new List<Contact>
                {
                    new Contact { contactId = 1, companyId = company.companyId, company = company, name = "Contact1" },
                    new Contact { contactId = 2, companyId = company.companyId, company = company, name = "Contact2" }
                };
                var body = DeconstructLists(company, "");
            }
            public static string DeconstructLists<T>(T obj, string body)
            {
                var type = obj.GetType();
                var properties = type.GetProperties();
                foreach (var property in properties)
                {
                    if (property.PropertyType == typeof(string) || property.PropertyType == typeof(int) || property.PropertyType == typeof(bool))
                        body += property.Name + " = " + property.GetValue(obj, null) + Environment.NewLine;
                    else
                    {
                        if (typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
                        {
                            body = body + property.Name + ": {" + Environment.NewLine;
                            var list = (IEnumerable)property.GetValue(obj, null);
                            foreach (var item in list)
                            {
                                body = body + item.GetType().Name + ": {" + DeconstructLists(item, "") + "}" + Environment.NewLine;
                            }
                            body = body + "}" + Environment.NewLine;
                        }
                    }
                }
                return body;
            }
        }
        public class Company
        {
            public int companyId { get; set; }
            public string name { get; set; }
            public string telephone { get; set; }
            public string regNumber { get; set; }
            public virtual IList<Asn> asns { get; set; }
            public virtual IList<Contact> contacts { get; set; }
        }
        public class Contact
        {
            public int contactId { get; set; }
            public int companyId { get; set; }
            public Company company { get; set; }
            public string name { get; set; }
            public string telephone { get; set; }
        }
        public class Asn
        {
            public int asnId { get; set; }
            public int companyId { get; set; }
            public Company company { get; set; }
            public bool userBehalf { get; set; }
            public bool something { get; set; }
        }
    }
