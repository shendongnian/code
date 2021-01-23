        List<Person> GameOfThrones = new List<Person>();
        GameOfThrones.Add(new Person("Rob Stark", 20, Gender.Male));
        GameOfThrones.Add(new Person("Sansa Stark", 16, Gender.Female));
        GameOfThrones.Add(new Person("The Mountain", 30, Gender.Transgender));
        GameOfThrones.Add(new Person("Mellisandra", 100, Gender.Female));
        GameOfThrones.Add(new Person("Ramsey Bolton", 20, Gender.Male));
         Search s = new Search(GameOfThrones );
