    var query = from feature in dbContext.FirmFeatures
    
                join parameter0 in dbContext.FirmParameters
                  on new { IsDbTable = feature.IsDbTable, FeatureId = feature.FeatureId } equals new { IsDbTable = false, FeatureId = parameter0.FeatureId ?? 0 }
                  into left_parameter_0
                  from parameter_0 in left_parameter_0.DefaultIfEmpty()
                
                join parameter1 in dbContext.FirmParameters
                  on new { IsDbTable = feature.IsDbTable, FeatureId = (byte?)null } equals new { IsDbTable = true, FeatureId = parameter1.FeatureId }
                  into left_parameter_1
                  from parameter_1 in left_parameter_1.DefaultIfEmpty()
    
    select new { Feature = feature, Parameter = parameter_0 != null ? parameter_0 : parameter_1 };
    
    var list = query.ToList();
