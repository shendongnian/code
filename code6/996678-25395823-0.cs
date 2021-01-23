    void Main()
    {
        var str = "{\r\n    \"name\":\"Chris\",\r\n    \"age\":100,\r\n    \"birthplace\":\"UK\",\r\n    \"height\":170," +
        "\r\n    \"birthdate\":\"08/08/1913\",\r\n}";
        var person = JsonConvert.DeserializeObject<Person>(str);
        Console.WriteLine(person.name);
        Console.WriteLine(person.other["birthplace"]);
    }
    
    class Person
    {
        public string name;
        public int age;
        public int height;
        [JsonExtensionData]
        public IDictionary<string, object> other;
    }
