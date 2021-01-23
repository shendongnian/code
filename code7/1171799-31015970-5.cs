        private static void Main(string[] args)
        {
            var livingHuman = new Person() { Age = 1, Name = "John Doe", Deceased = true };
            var deadHuman = new Person() { Age = 1, Name = "John Doe", Deceased = false };
            var humans = new List<Person> { livingHuman, deadHuman };
            XmlSerializer serializer = new XmlSerializer(typeof(Being));
            serializer.Serialize(Console.Out, new Being() { Humans = humans, Data = "some other data" });
        }
