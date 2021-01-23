    static void Main(string[] args)
    {
        // fill a list with Persons and Pupils
        var personalHeroes = new List<Person>()
		{
            new Person()
            {
                Name = "Charley Chaplin",
                BirthDay = new DateTime(1890, 8, 4),
                DeathDay = new DateTime(1977, 12, 25),
            },
            new Person()
            {
                Name = "Winston Churchill",
                BirthDay = new DateTime(1885, 4, 18),
                DeathDay = new DateTime(1965, 01,24),
            },
            new Person()
            {
                Name = "Pope Franciscus",
                BirthDay = new DateTime(1936, 12, 17)
                // not Death yet!
            },
        };
        // JSON serialize to file, also write result to screen
        var tmpFileName = System.IO.Path.GetTempFileName();
        using (TextWriter writer = new StreamWriter(tmpFileName))
        {
            string jsonTxt = JsonConvert.SerializeObject(personalHeroes , Formatting.Indented);
            Console.WriteLine(jsonTxt);
            writer.Write(jsonTxt);
        }
        // deserialize
        using (TextReader reader = new StreamReader(tmpFileName))
        {
            var jsonTxt = reader.ReadToEnd();
            var deserializedHeroes = JsonConvert.DeserializeObject<List<Person>>(jsonTxt);
        }
        File.Delete(tmpFileName);
    }
