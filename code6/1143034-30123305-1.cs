    [SettingsManageabilityAttribute(SettingsManageability.Roaming)]
    public abstract class GridSettingsBase : ApplicationSettingsBase, IGridSettings
    {
        [UserScopedSettingAttribute()]
        [DefaultSettingValue("")]
        [SettingsSerializeAs(SettingsSerializeAs.Xml)]
        public SerializableDictionary<string, int> GridDisplayIndexList
        {
            get { return (SerializableDictionary<string, int>)this["GridDisplayIndexList"]; }
            set { this["GridDisplayIndexList"] = value; }
        }
        [UserScopedSettingAttribute()]
        [DefaultSettingValue("")]
        [SettingsSerializeAs(SettingsSerializeAs.Xml)]
        public SerializableDictionary<string, Visibility> GridColumnVisibilityList
        {
            get { return (SerializableDictionary<string, Visibility>)this["GridColumnVisibilityList"]; }
            set { this["GridColumnVisibilityList"] = value; }
        }
        [UserScopedSettingAttribute()]
        [DefaultSettingValue("")]
        [SettingsSerializeAs(SettingsSerializeAs.Xml)]
        public SerializableDictionary<string, double> GridColumnWidthList
        {
            get { return (SerializableDictionary<string, double>)this["GridColumnWidthList"]; }
            set { this["GridColumnWidthList"] = value; }
        }
        [UserScopedSettingAttribute()]
        [DefaultSettingValue("")]
        [SettingsSerializeAs(SettingsSerializeAs.Xml)]
        public List<SortDescription> GridSortDescriptionList
        {
            get { return (List<SortDescription>)this["GridSortDescriptionList"]; }
            set { this["GridSortDescriptionList"] = value; }
        }
        protected GridSettingsBase()
        {
            Application.Current.Exit += OnExit;
        }
        private void OnExit(object sender, ExitEventArgs e)
        {
            this.Save();
        }
    }
