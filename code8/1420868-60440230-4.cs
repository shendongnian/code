    using (var textReader = new StringReader("Comma,Separated,Value,String"))
    {
        var persons = textReader.ParseCsvData(columns => new Person
        {
            Id = columns[0],
            Name = columns[1],
            Age = columns[2]
        });
        return persons.ToList();
    }
