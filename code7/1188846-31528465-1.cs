    public async Task<IList<Vehicle>> GetAll(Expression<Func<Vehicle, bool>>   condition)
    {
       // Return the results
       // _dao is type VehicleDao
       return await _dao.Find<T>(condition);
    }
    public async Task<IList<IVehicle>> GetAll(Expression<Func<IVehicle, bool>> condition)
    {
       // Return the results
       // _collection is my database managed collection (MongoDB in this case)
       return await _collection.Find<T>(condition).ToListAsync();
    }
