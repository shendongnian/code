    using System.Reflection;
      public static class EnumExtensions
    {
        public static string DisplayName(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            EnumDisplayNameAttribute attribute
                    = Attribute.GetCustomAttribute(field, typeof(EnumDisplayNameAttribute))
                        as EnumDisplayNameAttribute;
            return attribute == null ? value.ToString() : attribute.DisplayName;
        }
    }
    public class EnumDisplayNameAttribute : Attribute
    {
        private string _displayName;
        public string DisplayName
        {
            get { return _displayName; }
            set { _displayName = value; }
        }
    }
    class Enum
      {
             public enum Fields
    {       
        [EnumDisplayName(DisplayName = "Assigned To"
        AssignedTo,
        [EnumDisplayName(DisplayName = "Close Reason"
        CloseReason,
        [EnumDisplayName(DisplayName = "Customer ID"
        CustomerId,
        [EnumDisplayName(DisplayName = "Customer Name"
        CustomerName,
        [EnumDisplayName(DisplayName = "Company ID"
        CompanyID,
        [EnumDisplayName(DisplayName = "Company Name"
        CompanyName ,
    }
    }
