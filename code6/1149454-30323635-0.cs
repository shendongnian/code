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
            const string FILENAME = @"C:\temp\test.xml";
            static void Main(string[] args)
            {
                Root root = new Root()
                {
                    records = new List<Record>(){
                        new Record(){
                            type = "user",
                            fields = new List<Field>(){
                                new Field() { name= "userId",  value = "Id1"},
                                new Field() { name= "userName", value = "Name1"},
                                new Field() { name="userStreet", value = "Street1"},
                                new Field() { name="userCountry", value="Country1"}
                            }
                        },
                        new Record(){
                            type = "user",
                            fields = new List<Field>(){
                                new Field() { name = "userId", value="Id2"},
                                new Field() { name = "userName", value="Name2"},
                                new Field() { name= "userStreet", value="Street2"},
                                new Field() { name="userCountry", value="Country2"}
                            }
                        }
                    }
                };
                XmlSerializer serializer = new XmlSerializer(typeof(Root));
                StreamWriter writer = new StreamWriter(FILENAME);
                XmlSerializerNamespaces _ns = new XmlSerializerNamespaces();
                _ns.Add("", "");
                serializer.Serialize(writer, root, _ns);
                writer.Flush();
                writer.Close();
                writer.Dispose();
                XmlSerializer xs = new XmlSerializer(typeof(Root));
                XmlTextReader reader = new XmlTextReader(FILENAME);
                Root  newRoot = (Root)xs.Deserialize(reader);
                List<User> users = new List<User>();
                foreach (Record record in newRoot.records.AsEnumerable())
                {
                    User newUser = new User();
                    users.Add(newUser);
                    foreach (Field field in record.fields)
                    {
                        switch (field.name)
                        {
                            case "userId" :
                                newUser.UserId = field.value;
                                break;
                            case "userName":
                                newUser.UserName  = field.value;
                                break;
                            case "userStreet":
                                newUser.UserStreet = field.value;
                                break;
                            case "userCountry":
                                newUser.UserCountry = field.value;
                                break;
                        }
                    }
                }
                           
            }
        }
        [XmlRoot("Root")]
        public class Root
        {
            [XmlElement("record")]
            public List<Record> records { get; set; } 
        }
        [XmlRoot("record")]
        public class Record
        {
            [XmlAttribute("type")]
            public string type { get; set; }
            [XmlElement("field")]
            public List<Field> fields { get; set; } 
        }
        [XmlRoot("field")]
        public class Field
        {
            [XmlAttribute("name")]
            public string name { get; set; }
            [XmlAttribute("value")]
            public string value { get; set; }
        }
        class User
        {
            public string UserId { get; set; }
            public string UserName { get; set; }
            public string UserStreet { get; set; }
            public string UserCountry { get; set; }
        }
        
    }
