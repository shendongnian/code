    using System;
    using System.Collections.Generic;
    using System.Web.Script.Serialization;
    
    static class Program
    {
        static void Main()
        {
            var ser = new JavaScriptSerializer();
            ser.RegisterConverters(new[] { new PersonConverter() });
            var person = new Person
            {
                firstName = "Fred",
                lastName = "Jones",
                dob = new DateTime(1970, 1, 1)
            };
            var json = ser.Serialize(person);
            Console.WriteLine(json);
        }
    }
    
    class PersonConverter : JavaScriptConverter
    {
        public override IEnumerable<Type> SupportedTypes
        {
            get { yield return typeof(Person); }
        }
        public override IDictionary<string, object> Serialize(
            object obj, JavaScriptSerializer serializer)
        {
            var person = (Person)obj;
            return new Dictionary<string, object> {
                {"firstName", person.firstName },
                {"lastName", person.lastName }
            };
        }
        public override object Deserialize(
            IDictionary<string, object> dictionary, Type type,
            JavaScriptSerializer serializer)
        {
            object tmp;
            var person = new Person();
            if (dictionary.TryGetValue("firstName", out tmp))
                person.firstName = (string)tmp;
            if (dictionary.TryGetValue("lastName", out tmp))
                person.lastName = (string)tmp;
            return person;
        }
    }
    
    public class Person
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime dob { get; set; }
    }
