	List<ApiObject> GetObjects() {
		
		const int ITERATION_COUNT = 100;
		int objectsCount = GetAPICount();
		
		var ApiObjects = new List<ApiObject>();
		
		for (int i = 0; i < objectsCount; i+= ITERATION_COUNT) {
			
			// get the next 100
			var apiObjects = callToAPI(i, ITERATION_COUNT);	// pass the current offset, request the max per call
			ApiObjects.AddRange(apiObjects);
			
		}	// this loop will stop after you've reached objectsCount, so you should have all
		
		return ApiObjects;
	}
	// alternatively:
	List<ApiObject> GetObjects() {
		
		var nextObject = null;
		var ApiObjects = new List<ApiObject>();
		
        // get the first batch
		var apiObjects = callToAPI(null);
		ApiObjects.AddRange(apiObjects);
		nextObject = callResponse.nextObject;
		
        // and continue to loop until there's none left
		while (nextObject != null) {
			
			var apiObjects = callToAPI(null);
			ApiObjects.AddRange(apiObjects);
			nextObject = callResponse.nextObject;	
		}
		
		return apiObjects;	
	}
