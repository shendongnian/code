        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
            Prism.Regions.IRegionManager newRegion = Container.TryResolve<Prism.Regions.IRegionManager>();
            newRegion.RequestNavigate("ContentRegion", App.Experiences.MainPage.ToString());
        }
