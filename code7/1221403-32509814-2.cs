	public void Save(ControllerContext controllerContext, ITempDataProvider tempDataProvider)
	{
	    _data.RemoveFromDictionary((KeyValuePair<string, object> entry, TempDataDictionary tempData) =>
	        {
	            string key = entry.Key;
	            return !tempData._initialKeys.Contains(key) 
	                && !tempData._retainedKeys.Contains(key);
	        }, this);
	    tempDataProvider.SaveTempData(controllerContext, _data);
	}
