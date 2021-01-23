    IEnumerable<Person>  people = new []
    {
        new Person
        {
            Name = "Matthew"
        },
        new Person
        {
            Name = "Mark"
        }
    };
    people = people.OrderBy(x => x.Name, new MySorter());
