    public void Add(Car carToAdd)
    {
            var qry = (from car in Cars
                      where car.Registration == carToAdd.Registration 
                      select car).FirstOrDefault();
            if(qry == null)
            {
               Cars.Add(carToAdd);
            }
            else 
            {
               Console.WriteLine("Reg already exists!");
            }
    }
