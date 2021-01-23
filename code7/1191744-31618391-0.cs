    class Person
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
    }
    ...
    string jsonString = "[{'firstname':'john','lastname':'doe'},{'firstname':'mary','lastname':'jane'}]";
    Person[] personArray = JsonConvert.DeserializeObject<Person[]>(jsonString);
