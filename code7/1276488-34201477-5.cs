    this.moduleManager.LoadModuleCompleted += (s, e)
        {
			if (e.ModuleInfo.ModuleName == "ModuleItems")
			{
				regionManager.RequestNavigate(
                    RegionNames.TheUpperRegion,
                    typeof(ToolBarView).FullName), 
                    result => 
                    { 
                       // you can check here if the navigation was successful
                    });
				regionManager.RequestNavigate(
                    RegionNames.TheBottomRegion,
                    typeof(DockingView).FullName));
			}
        }
