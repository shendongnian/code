    List<int> listOfCountries = new List<int> { 2,3 };
    List<int> listOfCarIds = new List<int> { 4,5 };
        
    var query = from car in context.Cars.AsNoTracking()
    where car.Country.Id = 1 || (listOfCountries.Contains(car.Country.Id) && listOfCarIds.Contains(car.Id))
