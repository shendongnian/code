    var person = FunctionThatGetsPerson();
    List<Person> personList = new List<Person> { person };
    FunctionThatTakesEnumerable(personList);
    public void FunctionThatTakesEnumerable(IEnumerable<Person> personList)
    { 
        //
    }
