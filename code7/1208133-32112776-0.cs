    public ConfigurationDialogViewModel()
        {
            this.settings = new ObservableCollection<SettingsViewModelBase>();
            GeneralSettingsViewModel GeneralSettings1 = new GeneralSettingsViewModel();
            GeneralSettingsViewModel GeneralSettings2 = new GeneralSettingsViewModel();
            GeneralSettingsViewModel GeneralSettings3 = new GeneralSettingsViewModel();
            AdvancedSettingsViewModel AdvancedSettingsViewModel1 = new AdvancedSettingsViewModel();
            AdvancedSettingsViewModel AdvancedSettingsViewModel2 = new AdvancedSettingsViewModel();
            AdvancedSettingsViewModel AdvancedSettingsViewModel3 = new AdvancedSettingsViewModel();
            GeneralSettings1.Name = "keks1";
            GeneralSettings2.Name = "keks2";
            GeneralSettings3.Name = "keks3";
            AdvancedSettingsViewModel1.Name = "banana1";
            AdvancedSettingsViewModel2.Name = "banana2";
            AdvancedSettingsViewModel3.Name = "banana3";
            this.settings.Add(GeneralSettings1);
            this.settings.Add(GeneralSettings2);
            this.settings.Add(GeneralSettings3);
            this.settings.Add(AdvancedSettingsViewModel1);
            this.settings.Add(AdvancedSettingsViewModel2);
            this.settings.Add(AdvancedSettingsViewModel3);
        }
