    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                People people = new People();
                People person = people.GetPeople(FILENAME);
            }
        }
        [XmlRoot("people")]
        public class People
        {
            [XmlElement("person")]
            public List<Person> person { get; set; }
            public People GetPeople(string filename)
            {
                People person = null;
                XmlSerializer serializer = new XmlSerializer(typeof(People));
                using (XmlTextReader reader = new XmlTextReader(filename))
                {
                    person = (People)serializer.Deserialize(reader);
                }
                return person;
            }
        }
        [XmlRoot("person")]
        public class Person
        {
            [XmlElement("author_id")]
            public int author_id { get; set; }
            [XmlElement("background")]
            public string background { get; set; }
            [XmlElement("company_id")]
            public int company_id { get; set; }
            [XmlElement("created_at")]
            public DateTime created_at { get; set; }
            [XmlElement("first_name")]
            public string first_name { get; set; }
            [XmlElement("group_id")]
            public int group_id { get; set; }
            [XmlElement("id")]
            public long id { get; set; }
            [XmlElement("last_name")]
            public string last_name { get; set; }
            [XmlElement("owner_id")]
            public int owner_id { get; set; }
            [XmlElement("company_name")]
            public string company_name { get; set; }
            [XmlElement("avatar_url")]
            public string avatar_url { get; set; }
            [XmlElement("contact-data")]
            public Contact_Data contact_data { get; set; }
        }
        [XmlRoot("contact-data")]
        public class Contact_Data
        {
            [XmlElement("phone-numbers")]
            public Phone_Numbers phone_numbers { get; set; }
        }
        [XmlRoot("phone-numbers")]
        public class Phone_Numbers
        {
            [XmlElement("phone-number")]
            public List<Phone_Number> phone_number { get; set; }
        }
        [XmlRoot("phone-number")]
        public class Phone_Number
        {
            [XmlElement("id")]
            public int id { get; set; }
            [XmlElement("location")]
            public string location { get; set; }
            [XmlElement("number")]
            public string number { get; set; }
        }
    }
