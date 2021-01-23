    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication7
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                Person.people = doc.Descendants("person").Select(x => new Person()
                {
                    id = (int)x.Element("author-id"),
                    client_id = (int)x.Element("company-id"),
                    first_name = (string)x.Element("first-name"),
                    last_name = (string)x.Element("last-name"),
                    email = (string)x.Descendants("email-addresses").FirstOrDefault(),
                    phone_office = x.Descendants("phone-number").Where(y => (string)y.Element("location") == "Work").Select(z => (string)x.Descendants("number").FirstOrDefault()).FirstOrDefault(),
                    phone_mobile = x.Descendants("phone-number").Where(y => (string)y.Element("location") == "Mobile").Select(z => (string)x.Descendants("number").FirstOrDefault()).FirstOrDefault(),
                    fax = x.Descendants("phone-number").Where(y => (string)y.Element("location") == "Fax").Select(z => (string)x.Descendants("number").FirstOrDefault()).FirstOrDefault(),
                    title = (string)x.Element("title"),
                    createad_at = (DateTime)x.Element("created-at"),
                    updated_at = (DateTime)x.Element("updated-at"),
                }).ToList();
            }
        }
        public class Person
        {
            public static List<Person> people = new List<Person>(); 
            public int id { get; set; }
            public int client_id { get; set; }
            public string first_name { get; set; }
            public string last_name { get; set; }
            public string email { get; set; }
            public string phone_office { get; set; }
            public string phone_mobile { get; set; }
            public string fax { get; set; }
            public string title { get; set; }
            public DateTime createad_at { get; set; }
            public DateTime updated_at { get; set; }
            public bool isFromHighriseOrHarvest { get; set; }
        }
    }
