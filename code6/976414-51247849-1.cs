    public class DemoController: Controller
            public async Task<FileStreamResult> GetLogoImage(string logoimage)
            {
                string str = "" ;
                var filePath = Server.MapPath("~/App_Data/" + SubfolderName);//If subfolder exist otherwise leave.
                // DirectoryInfo dir = new DirectoryInfo(filePath);
                string[] filePaths = Directory.GetFiles(@filePath, "*.*");
                foreach (var fileTemp in filePaths)
                {
                      str= fileTemp.ToString();
                }
                    return File(new MemoryStream(System.IO.File.ReadAllBytes(str)), System.Web.MimeMapping.GetMimeMapping(str), Path.GetFileName(str));
            }
           
             
