    //This is the comparison class
    CompareLogic compareLogic = new CompareLogic();
    //Create a couple objects to compare
    Person person1 = new Person();
    person1.DateCreated = DateTime.Now;
    person1.Name = "Greg";
    Person person2 = new Person();
    person2.Name = "John";
    person2.DateCreated = person1.DateCreated;
    ComparisonResult result = compareLogic.Compare(person1, person2);
    //These will be different, write out the differences
    if (!result.AreEqual)
       Console.WriteLine(result.DifferencesString);
