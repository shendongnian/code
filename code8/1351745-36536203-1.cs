    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.IO;
    using System.Web.Script.Services;
    using System.Web.Services;
    
    namespace WebApplication12
    {
    [ScriptService]
    public partial class WebForm1 : System.Web.UI.Page
    {
        static string path = @"C:\Users\Yegor\Documents\Visual Studio 2015\Projects\WebApplication12\WebApplication12\Images\";
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        [WebMethod()]
        public static void UploadImage(string imageData)
        {
            string fileNameWitPath = path + DateTime.Now.ToString().Replace("/", "-").Replace(" ", "- ").Replace(":", "") + ".png";
            using (FileStream fs = new FileStream(fileNameWitPath, FileMode.Create))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    byte[] data = Convert.FromBase64String(imageData);
                    bw.Write(data);
                    bw.Close();
                }
            }
        }
    }
    }
