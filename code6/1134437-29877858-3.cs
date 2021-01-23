    public IEnumerable<Vehicle> GetVehicles(Expression<Func<Vehicle, bool>> predicate = null)
    {
        using (DataManager db = new DataManager())
        {
            if (predicate == null)
                return db.Vehicles.ToList();
    
            var vehicles = db.Vehicles.Where(predicate).ToList();
            return vehicles;
        }
    }
    public ActionResult Index()
    {
        IVehicleService service = new VehicleService();
        var allVehicles = service.GetVehicles();
        var vehicleWorkRequest = service.GetVehicles(v => v.Closed == false);
        var vehicleCriticalWorkRequests = service.GetVehicles(v => v.Closed == false && v.Critical == true).OrderByDescending(v => v.DateReported);
        var vehicleRoutineWorkRequests= service.GetVehicles(v => v.Closed == false && v.Critical == false).OrderByDescending(v => v.DateReported);
        var vehicleCompletedWorkRequests = service.GetVehicles(v => v.Closed == true).OrderByDescending(v => v.DateReported);
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
