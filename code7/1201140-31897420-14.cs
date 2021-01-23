    namespace WebTester
    {
        public partial class WebUserControl1 : System.Web.UI.UserControl
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            public static string ProcessIT(string name, string address)
            {
                var fi = new FileInfo(HttpContext.Current.Request.FilePath);
                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fi.Name);
                string result = string.Format("Name '{0}' and address '{1}' came from Page '{2}'", name, address, fileNameWithoutExtension);
                return result;
            }
        }
    }
