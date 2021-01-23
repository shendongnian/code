    if (burnerID != null)
    {
    	ViewBag.BurnerID = burnerID.Value;
    	viewModel.BurnPiles = viewModel.BurnProjects.SingleOrDefault(b => b.BurnerID == burnerID.Value)?.BurnPiles;
    }
