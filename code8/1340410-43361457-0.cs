    var vehicles = 
    	_context.Vehicles
    		.Select(v => 
    			new StatisticsVehicle()
    			{
    				PlateNumber =v.PlateNumber,
    				StatisticsVehicleProcesses = 
    					v.VehicleProcesses.Select(vp => new StatisticsVehicleProcess()
    					{
    						EffectiveIssuanceDate = vp.EffectiveIssuanceDate,
    						PlannedIntakeEndDate = vp.PlannedIntakeEndDate
    					})
    			}
    		)
    		.ToList();
