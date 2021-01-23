    protected override void OnCreate(Bundle bundle)
    {
    
            base.OnCreate(bundle);
            
            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            SetContentView(Resource.Layout.Main);
           
            ActionBar.Tab Pudisoo = ActionBar.NewTab();
            Pudisoo.SetText("Pudisoo");
            Pudisoo.SetIcon(Resource.Drawable.Pudisoo_selected);
            Pudisoo.TabSelected += Pudisoo_TabSelected;
            ActionBar.AddTab(Pudisoo);
    
            ActionBar.Tab Settings = ActionBar.NewTab();
            Settings.SetText("Settings");
            Settings.SetIcon(Resource.Drawable.Pudisoo_selected);
            Settings.TabSelected += Settings_TabSelected;
            ActionBar.AddTab(Settings);
    }
