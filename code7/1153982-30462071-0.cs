    var errores = new List<ModelError>();
	foreach (ModelState modelState in ViewData.ModelState.Values)
	{
		foreach (ModelError error in modelState.Errors)
		{
			errores.Add(error);
		}
	}
