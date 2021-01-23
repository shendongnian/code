    public static List<MY_CARS> GetAllCars()
    {
        using (var context = new Entities())
        {
            return context.MY_CARS.AsNoTracking().ToList();
        }
    }
