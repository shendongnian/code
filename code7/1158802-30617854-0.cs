    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication32
    {
        class Program
        {
            const string FILENAME = @"c:\temp\Test.xml";
            static void Main(string[] args)
            {
                XmlSerializer xs = new XmlSerializer(typeof(Query));
                XmlTextReader reader = new XmlTextReader(FILENAME);
                Query query = (Query)xs.Deserialize(reader);
                query.Response.GetContacts();
     
            }
        }
        [XmlRoot("query")]
        public class Query
        {
            [XmlElement("parameters")]
            public Parameters Parameters {get;set;}
            [XmlElement("response")]
            public Response Response {get;set;}
        }
        [XmlRoot("parameters")]
        public class Parameters{
            private string lastUpdate {get;set;}
            private string code {get;set;}
            private string type {get;set;}
            
            [XmlElement("param")]
            public List<Param> m_params {get; set;}
         
        }
        [XmlRoot("param")]
        public class Param
        {
            [XmlAttribute("name")]
            public string name {get; set;} 
        }
        [XmlRoot("response")]
        public class Response
        {
          private Person person {get;set;}
          private List<Contact> contacts = new List<Contact>();
          [XmlElement("category")]
          public List<Category> categories {get;set;}
          public void GetContacts()
          {
              foreach (Category category in categories)
              {
                  string catName = category.name;
                  switch (catName)
                  {
                      case "person" :
                          person = new Person();
                          foreach (Field field in category.fields)
                          {
                              switch (field.name)
                              {
                                  case "surname" :
                                      person.surname = field.value;
                                      break;
                                  case "name1":
                                      person.name1 = field.value;
                                      break;
                                  case "date_of_birth":
                                      person.date_of_birth = field.value;
                                      break;
                                  default :
                                      break;
                              }
                          }
                          break;
                      case "contact" :
                          foreach (Row row in category.row)
                          {
                              Contact newContact = new Contact();
                              contacts.Add(newContact);
                              foreach (Field field in row.fields)
                              {
                                  switch (field.name)
                                  {
                                      case "phone":
                                          newContact.phone = field.value;
                                          break;
                                      case "type":
                                          newContact.type = field.value;
                                          break;
                                      case "date":
                                          newContact.date = field.value;
                                          break;
                                      default:
                                          break;
                                  }
                              }
                          }
                          break;
                  }
              }
          }
        }
        [XmlRoot("category")]
        public class Category
        {
            [XmlAttribute("name")]
            public string name {get; set;}
            [XmlAttribute("version")]
            public string version { get; set; }
            [XmlElement("field")]
            public List<Field> fields {get; set;}
            [XmlElement("row")]
            public List<Row> row {get;set;}
        }
        [XmlRoot("row")]
        public class Row
        {
            [XmlElement("field")]
            public List<Field> fields {get; set;}
        }
        [XmlRoot("field")]
        public class Field
        {
            [XmlAttribute("name")]
            public string name { get; set; }
            [XmlText]
            public string value { get; set; }
        }
        class Person {
          public string surname {get;set;}
          public string name1 {get;set;}
          public string date_of_birth {get;set;}
        }
        class Contact {
          public string phone {get;set;}
          public string type {get;set;}
          public string date {get;set;}
        }
    }
