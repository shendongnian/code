    public class TenantCustomizationController : RecruitControllerBase
    
        //enter code here
    
    [AllowAnonymous]
            [HttpGet]
            public async Task<FileStreamResult> GetLogoImage(string logoimage)
            {
                string str = "" ;
                var filePath = Server.MapPath("~/App_Data/" + AbpSession.TenantId.Value);
                // DirectoryInfo dir = new DirectoryInfo(filePath);
                string[] filePaths = Directory.GetFiles(@filePath, "*.*");
                foreach (var fileTemp in filePaths)
                {
                      str= fileTemp.ToString();
                }
                    return File(new MemoryStream(System.IO.File.ReadAllBytes(str)), System.Web.MimeMapping.GetMimeMapping(str), Path.GetFileName(str));
            }
            //09/07/2018
             
    Here Is my View
                                
    <div><a href="/TenantCustomization/GetLogoImage?Type=Logo" target="_blank">@L("DownloadBrowseLogo")</a></div>
       
