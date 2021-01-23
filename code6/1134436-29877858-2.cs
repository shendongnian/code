    public async Task<IEnumerable<Vehicle>> GetVehicles(Expression<Func<Vehicle, bool>> predicate = null)
    {
        using (DataManager db = new DataManager())
        {
            if (predicate == null)
                return await db.Vehicles.ToListAsync();
    
            var vehicles = db.Vehicles.Where(predicate).ToListAsync();
            return await vehicles;
        }
    }
    public async Task<ActionResult> Index()
    {
        IVehicleService service = new VehicleService();
        var allVehicles = await service.GetVehiclesAsync();
        var vehicleWorkRequest = await service.GetVehiclesAsync(v => v.Closed == false);
        var vehicleCriticalWorkRequests = await service.GetVehiclesAsync(v => v.Closed == false && v.Critical == true).OrderByDescending(v => v.DateReported);
        var vehicleRoutineWorkRequests= await service.GetVehiclesAsync(v => v.Closed == false && v.Critical == false).OrderByDescending(v => v.DateReported);
        var vehicleCompletedWorkRequests = await service.GetVehiclesAsync(v => v.Closed == true).OrderByDescending(v => v.DateReported);
        var Model = new HomeViewModel
            {
                Vehicles = allVehicles,
                VehicleCount = allVehicles.Count(),
                VehicleWorkRequestCount = vehicleWorkRequest.Count(),
                VehicleWorkRequests = vehicleWorkRequest,
                VehicleCriticalWorkRequests = ehicleCriticalWorkRequests,
                VehicleRoutineWorkRequests = vehicleRoutineWorkRequests,
                VehicleCompletedWorkRequests = vehicleCompletedWorkRequests
            };
        return View(Model);
        }
    }
