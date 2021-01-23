    try
	{
		var controlToLoad = "Controls/ArticleList.ascx";
		if (ArticleId > 0)
			controlToLoad = "Controls/ArticleView.ascx";
		var mbl = (dnnsimplearticleModuleBase)LoadControl(controlToLoad);
		mbl.ModuleConfiguration = ModuleConfiguration;
		mbl.ID = System.IO.Path.GetFileNameWithoutExtension(controlToLoad);
		phViewControl.Controls.Add(mbl);
	}
	catch (Exception exc) //Module failed to load
	{
		Exceptions.ProcessModuleLoadException(this, exc);
	}
