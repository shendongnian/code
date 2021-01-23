    model.Tps = _FoxDB.DWH_TrainingProgramsBasicData
    				.AsEnumerable() // I added this
    				.Where(t => 
    					model.events
    						.Any(e => e.EventTrainingProgram_ID.Equals(t.TrainingProgramID)))
    						.Select(t => new EntityDropDown()
    						{
    							ID = t.TrainingProgramID,
    							Name = t.TrainingProgramName
    						}).ToList();
