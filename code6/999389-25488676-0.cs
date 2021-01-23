    using (EntitiesModel context = new EntitiesModel())
    {
        var rentalOrdersToDelete = context.RentalOrders.Where(order => order.RentalOrderID < 10);
        var carsToDelete = context.Cars.Where(car => car.CarID < 5);
        foreach (RentalOrder order in rentalOrdersToDelete)
        {
            context.Delete(order);
        }
        foreach (Car car in carsToDelete)
        {
            context.Delete(car);
        }
        context.SaveChanges();
    }
