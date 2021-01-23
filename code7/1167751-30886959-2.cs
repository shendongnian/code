    public IEnumerable<Person> GetPersonsWithCars(Person person)
    {
        var personReturned = false;
        if (person.Cars.Any())
        {
            yield return person;
            personReturned = true;
        }
        foreach (var child in person.Children)
        {
             foreach (var item in GetPersonsWithCars(child))
             {
                 if (!personReturned)
                 {
                     yield return person;
                     personReturned = true;
                 }
                 yield return item;
             }
        }
    }
