    var people = new List<Person>();
    people.Add(new Person(){ Name = "Cheryl Cole", Gender = Gender.Female });
    people.Add(new Person(){ Name = "Hilary Clinton", Gender = Gender.Female });
    people.Add(new Person(){ Name = "Noel Gallagher", Gender = Gender.Male });
    int mCount = 0;
    int fCount = 0;
    foreach (var person in people)
    {
        if (person.Gender == Gender.Male)
            mCount += 1;
        else if (person.Gender == Gender.Female)
            fCount += 1;
    }
    Console.WriteLine("mCount = {0}", mCount);
    Console.WriteLine("fCount = {0}", fCount);
    Console.Read();
