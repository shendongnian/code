    var lookup = new Dictionary<int, Person>();
    using (IDbConnection cnn = GetOpenConnection())
    {
        var people = cnn.Query <Person, Car, Person>(query, (per, car) =>
        {
            Person found;
            if (!lookup.TryGetValue(per.PersonID, out found))
            {
                found = per;
                lookup.Add(per.PersonID, found);
                found.Cars = new List<Car>();
            }
            found.Cars.Add(car);
            return found;
        }, splitOn: "CarID").Distinct();
    }
    
