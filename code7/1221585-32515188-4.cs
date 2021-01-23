    class NewVehicleFuelReportViewModel
    {
       public int Index { get; set; }
       public MaintenanceDate { get; set; }
    }
    
    var data = maintenance.Join(mDetail,
       m => m.Id,
       md => md.MaintenanceId,
       ( m, md) => new VehicleFuelReportViewModel { 
          MaintenanceDate = m.MaintenanceDate 
       });
       int i = 0;
       var dataWithIndex = data.select(d=>{
       var tempdata = new NewVehicleFuelReportViewModel();
       tempdata.Indx = i++;
       tempdata.MaintenanceDate = d.MaintenanceDate;
       return tempdata;
    }).ToList();
