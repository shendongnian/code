    public enum ContainerStatus
    {
        [Display(Description = "Container processed")]
        Processed,
        [Display(Description = "Container ready to ship")]
        ReadyToShip,
        [Display(Description = "Container sent")]
        Sent
    }
    public static class EnumExtensions
    {
        public static string Description(this Enum value)
        {
            var enumType = value.GetType();
            var field = enumType.GetField(value.ToString());
            var attributes = field.GetCustomAttributes(typeof(DisplayAttribute),
                                                       false);
            return attributes.Length == 0
                ? value.ToString()
                : ((DisplayAttribute)attributes[0]).Description;
        }
    }
    public partial class WebForm1 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {       
            var values = Enum.GetValues(typeof(ContainerStatus)).Cast<ContainerStatus>();
            foreach (var v in values)
            {
                DropDownList1.Items.Add(v.Description());                
            }
        }
    }
