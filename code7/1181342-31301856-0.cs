    var query = from feature in dbContext.FirmFeatures
                
                join parameter0 in dbContext.FirmParameters
                  on new { IsDbTable = feature.IsDbTable, FeatureId = feature.FeatureId } = new { IsDbTable = 0, FeatureId = parameter0.FeatureId }
                  into left_parameter_0
                  from parameter_0 in left_parameter_0.DefaultIfEmpty()
                  
                join parameter1 in dbContext.FirmParameters
                  on new { IsDbTable = feature.IsDbTable, FeatureId = null } = new { IsDbTable = 1, FeatureId = parameter1.FeatureId }
                  into left_parameter_1
                  from parameter_1 in left_parameter_1.DefaultIfEmpty()
                  
                select new { Feature = feature, Parameter = parameter0 != null ? parameter0 : parameter1 };
    
	var list = query.ToList();
