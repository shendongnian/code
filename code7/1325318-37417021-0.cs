    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    
    namespace ConsoleApplication1
    {
        public class Program
        {
            static void Main(string[] args)
            {
                var settings = new Settings();
                settings.People.Add(new Person { Name = "Name", LastName = "LastName", City="City", Country="Country", Date="11/11/11", Details="Details", Email="Email", Phone="Phone", State="State", Street="Steet" });
                settings.Save("c:\\test.xml");
                settings = Settings.TryLoad("c:\\test.xml");
            }
    
            [Serializable]
            public class Settings
            {
                public Settings()
                {
                }
    
                public List<Person> People
                {
                    get { return people; }
                    set { people = value; }
                }
                List<Person> people = new List<Person>();
    
                public void Save(string path)
                {
                    XmlSerializer xs = new XmlSerializer(typeof(Settings));
                    using (var sw = new StreamWriter(File.Open(path, FileMode.OpenOrCreate)))
                    {
                        xs.Serialize(sw, this);
                    }
                }
    
                public static Settings TryLoad(string path)
                {
                    Settings settings = null;
                    XmlSerializer xs = new XmlSerializer(typeof(Settings));
                    using (var sw = new StreamReader(File.OpenRead(path)))
                    {
                        try
                        {
                            settings = xs.Deserialize(sw) as Settings;
                        }
                        catch (Exception)
                        {
                            // skip
                        }
                    }
                    return settings;
                }
            }
    
            [Serializable]
            public class Person
            {
                public Person()
                {
                }
    
                public string Name { get; set; }
                public string LastName { get; set; }
                public string Street { get; set; }
                public string Phone { get; set; }
                public string Email { get; set; }
                public string Date { get; set; }
                public string City { get; set; }
                public string State { get; set; }
                public string Country { get; set; }
                public string Details { get; set; }
            }
        }
    }
