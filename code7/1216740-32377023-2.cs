	public async Task AddPatientReportDentalChartAsync(AddPatientReportDentalChartInput input)
	{
		var pid = input.PatientID;
		var chartdetails = _chartReportRepository
							.GetAll()
							.WhereIf(!(pid.Equals(0)),
									   p => p.PatientID.Equals(pid)).ToList();
	
		if (chartdetails.Count > 0)
		{
			var entity = await _chartReportRepository
									.YourTableName
									.FindAsync(entity => entity.SomeId == matchingId);
				
			entity.PropertyA = "something"
			entity.PropertyB = 1;
			await _chartReportRepository.SaveChangesAsync();
		}
		else 
		{ 
			var patientinfo = input.MapTo<PatientReportDentalChart>();
			await _chartReportRepository.InsertAsync(patientinfo);
		}
	}
