    public class EnumDisplayNameAttribute : Attribute
    {
        private string _displayName;
        public string DisplayName
        {
            get { return _displayName; }
            set { _displayName = value; }
        }
    }  
    
    public enum eUserRole : int
    {
        [EnumDisplayName(DisplayName = "Super Admin")]
        SuperAdmin = 0,
        [EnumDisplayName(DisplayName = "Phoenix Admin")]
        PhoenixAdmin = 1,
        [EnumDisplayName(DisplayName = "Office Admin")]
        OfficeAdmin = 2,
        [EnumDisplayName(DisplayName = "Report User")]
        ReportUser = 3,
        [EnumDisplayName(DisplayName = "Billing User")]
        BillingUser = 4
    }
