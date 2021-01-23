    using UmbracoImportExportPlugin.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using Umbraco.Core.Persistence;
    using Umbraco.Web;
    using Umbraco.Web.WebApi;
    
    namespace UmbracoImportExportPlugin.App_Code
    {
    
        public class ImportNewDictionaryController : UmbracoAuthorizedApiController
        {
            public string basePath;
            
            //Locate specific path
            public void LocatePath()
            {
                this.basePath = System.Web.Hosting.HostingEnvironment.MapPath(@"/upload");
            }
            [System.Web.Http.AcceptVerbs("GET", "POST")]
            //[System.Web.Http.HttpPost]
            public void SaveFile()
            {
                var myContext = Request.TryGetHttpContext();
                List<string> keys = new List<string>();
                if (myContext.Success)
    
                {
                    HttpPostedFileBase myFile = myContext.Result.Request.Files["file"];
                    if (myFile == null)
                    {
                       throw new HttpException("invalid file");
                    }
                    else
                    {
                        StreamReader csvreader = new StreamReader(myFile.InputStream);
                        
    
                        while (!csvreader.EndOfStream)
                        {
                            var line = csvreader.ReadLine();
                            if (line != "Key")
                            keys.Add(line);
                        }
                    }
                    UmbracoDatabase db = ApplicationContext.DatabaseContext.Database;
                    var remove = new Sql("DELETE FROM cmsDictionary");
                    int rem = db.Execute(remove);
                    foreach (string item in keys)
                    {
                        var insert = new Sql("INSERT INTO cmsDictionary VALUES (NEWID(), null,'" + item + "')");
                        int res = db.Execute(insert);
                    }
                }
            }
    
            
        }
    }
