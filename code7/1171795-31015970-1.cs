        private static void Main(string[] args)
        {
            var livingHuman = new Person() { Age = 1, Name = "John Doe", Deceased = true };
            var deadHuman = new Person() { Age = 1, Name = "John Doe", Deceased = false };
            XmlSerializer serializer = new XmlSerializer(typeof(Being));
            serializer.Serialize(Console.Out, new Being { Human = livingHuman, Data = "new" });
            serializer.Serialize(Console.Out, new Being { Human = deadHuman, Data = "old" });
        }
