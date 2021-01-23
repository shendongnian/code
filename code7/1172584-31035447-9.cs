    public JsonResult SaveCategory(StatesTypes state, int categoryId)
    {
    	CategoryJsonViewModel ret = new CategoryJsonViewModel();
    
    	ret.Response = //Use EF here - perhaps call a service object to save the category?
		if(ret.Response == BaseJsonResponseTypes.Success)
		{
			if(state == StatesTypes.Disabled)
			{
				ret.Message = "Category successfully disabled";
			}
			else
			{
				ret.Message = "Category successfully enabled";
			}
		}
		else
		{
			ret.Message = "Critical error :-(";
		}
    
    	return Json(ret);
    }
