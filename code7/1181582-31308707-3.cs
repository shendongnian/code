    List<Person> lstPersons = new List<Person>();
    foreach (var person in _result)
    {
        List<Car> lstCars = new List<Car>();
        lstCars=person.CarsOwnedByHim.Where(x => x.ModelName.ToUpper() != "COROLLA").ToList();
        person.CarsOwnedByHim = lstCars;
        lstPersons.Add(person);
    
    }
    return lstPersons ;
