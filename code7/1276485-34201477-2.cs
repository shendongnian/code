    this.moduleManager.LoadModuleCompleted += (s, e)
        {
			if (e.ModuleInfo.ModuleName == "ModuleItems")
			{
				regionManager.RequestNavigate(
                    RegionNames.TheUpperRegion,
                    typeof(ModuleItemsView).FullName), 
                    result => 
                    { 
                       // you can check here if the navigation was successful
                    });
			}
        }
