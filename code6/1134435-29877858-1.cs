    public async Task<IEnumerable<Vehicle>> GetVehiclesAsync(Expression<Func<Vehicle, bool>> predicate = null)
    {
        using (DataManager db = new DataManager())
        {
            if (predicate == null)
                return await db.Vehicles.ToListAsync();
    
            var vehicles = await db.Vehicles.Where(predicate).ToListAsync();
            return vehicles;
        }
    }
    
