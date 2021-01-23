    if (viewModel.ReturnUrl.IsNotNullOrEmptyTrimmed())
   	{
    	return RedirectToLocal(viewModel.ReturnUrl, "ActionName", "ControllerName");
   	}
    else
   	{
        // Default hard coded redirect
   	}
