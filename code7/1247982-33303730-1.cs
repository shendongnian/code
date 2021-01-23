    public void Add(Car carToAdd)
    {
        if ( !Cars.Any(c => c.Registration == carToAdd.Registration) )
        {
            Cars.Add(carToAdd);
        }
        else 
        {
            // handle case where car is already in the list
        }
    }
