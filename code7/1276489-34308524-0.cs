    private void DoLogin(object obj)
        {
            ShowAnotherView = false;
            if (UserName == "1" && UserPassword == "1")
            {                
                container.RegisterType<Object, TheUpperControl>("ModuleItems");
                Uri viewNav = new Uri("ModuleItems", UriKind.Relative);
                regionManager.RequestNavigate(RegionNames.TheUpperRegion, viewNav);
                regionManager.RequestNavigate(RegionNames.TheBottomRegion, viewNav);
                LoadTheOtherModule(); //load the other module
                var loginView = regionManager.Regions[RegionNames.TheWholeRegion].Views.ElementAt(0);
                regionManager.Regions[RegionNames.TheWholeRegion].Remove(loginView); //remove the login view
                //MessageBox.Show("");    
            }
            else
                ShowPromptingMessage = true;
        }
        private void LoadTheOtherModule()
        {
            Type moduleType = typeof(ModuleItems.ModuleItemsModule);
            ModuleInfo mi = new ModuleInfo()
            {
                ModuleName = moduleType.Name,
                ModuleType = moduleType.AssemblyQualifiedName,
            };
            IModuleCatalog catalog = container.Resolve<IModuleCatalog>();
            catalog.AddModule(mi);
            catalog.Initialize();
            IModuleManager moduleManager = container.Resolve<IModuleManager>();
            moduleManager.LoadModule(moduleType.Name); //run Initialize() of the other module
        }
