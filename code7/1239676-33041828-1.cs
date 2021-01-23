    public abstract class DashboardModuleCommonSettings
    {        
        public int ForwarderId { get; set; }
        public int ClientSubsidiaryId { get; set; }
        public bool IsContentUpdateable { get; set; }
        public int? AfterTime { get; set; }
        public string Title { get; set; }
    
        [SkipProperty]
        public string ModuleSettingsPopupName { get; set; }
    
        [SkipProperty]
        public int ClientId { get; set; }
    
        [SkipProperty]
        [HiddenInput(DisplayValue = false)]
        public string CurrentLayout { get; set; }
    }
