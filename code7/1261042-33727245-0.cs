    public ActionResult Index(int? page)
    {
        var cookie = new HttpCookie("view", "admin");
        var portalViewModel = new List<PortalViewModel>();
        var vehicles = db.Vehicles.ToList();
        var totalNumberOfUrgentItems = 0; // first total
        var totalNumberOfItemsRequireingAttention = 0; // second total
        foreach (var vehicle in vehicles)
        {
            var vm = new PortalViewModel { Vehicle = vehicle };
            if (vehicle.MotDate == null)
            {
                vm.MotNotRecorded = true;
                vm.NumberOfUrgentItems++;
            }
            if (vehicle.TaxDate == null)
            {
                vm.TaxNotRecorded = true;
                vm.NumberOfUrgentItems++;
            }
            if (vehicle.MotDate <= DateTime.Now.AddYears(-1))
            {
                vm.MotExpired = true;
                vm.NumberOfUrgentItems++;
            }
            if (vehicle.TaxDate != null && DateTime.Now.Subtract((DateTime)vehicle.TaxDate).Days >= 7)
            {
                vm.TaxWithin7Days = true;
            }
            else if (vehicle.TaxDate != null && DateTime.Now.Subtract((DateTime)vehicle.TaxDate).Days >= 30)
            {
                vm.TaxWithin30Days = true;
            }
            totalNumberOfUrgentItems += vehicle.NumberOfUrgentItems;
            totalNumberOfItemsRequireingAttention += vehicle.ItemsRequireingAttention;
            portalViewModel.Add(vm);
        }
        ViewBag["TotalNumberOfUrgentItems"] = totalNumberOfUrgentItems;
        ViewBag["TotalNumberOfItemsRequireingAttention"] = totalNumberOfItemsRequireingAttention;
        // presumably your return statement is here
    }
