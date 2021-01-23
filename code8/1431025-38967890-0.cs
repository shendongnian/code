    public partial class CallingWebMethodFromJS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        [System.Web.Services.WebMethod]
        public static string Get_Data(Parameters parameters)
        {
            System.Diagnostics.Debugger.Break();
            return "";
        }
    }
    public class Parameters
    {
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public string Value3 { get; set; }
    }
