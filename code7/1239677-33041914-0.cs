    public abstract class DashboardModuleCommonSettings
    {        
        public int ForwarderId { get; set; }
        public int ClientSubsidiaryId { get; set; }
        public bool IsContentUpdateable { get; set; }
        public int? AfterTime { get; set; }
        public string Title { get; set; }
        [NotRequiredForUniqueName]
        public string ModuleSettingsPopupName { get; set; }
        [NotRequiredForUniqueName]
        public int ClientId { get; set; }
        [NotRequiredForUniqueName]
        [HiddenInput(DisplayValue = false)]
        public string CurrentLayout { get; set; }
    }
