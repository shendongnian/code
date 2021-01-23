    using System;
    using System.Diagnostics;
    using DotNetOpenAuth.OAuth2;
    using Google.Apis.Authentication.OAuth2;
    using Google.Apis.Authentication.OAuth2.DotNetOpenAuth;
    using Google.Apis.Drive.v2;
    using Google.Apis.Drive.v2.Data;
    using Google.Apis.Util;
    using ASPSnippets.GoogleAPI;
    using System.Web.Script.Serialization;
    using System.Web;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net;
    using System.IO;
    using System.Reflection;
    
    namespace WebApplication1
    {
        public partial class GoogleDriveSample : System.Web.UI.Page
        {
            static int flagUpdateFile;
            protected string[] dirs = Directory.GetFiles(@"C:\Users\Michael\Desktop\GoogleDrive1");
            
    
            protected void Page_Load(object sender, EventArgs e)
            {
                GoogleConnect.ClientId = "";
                GoogleConnect.ClientSecret = "";
                GoogleConnect.RedirectUri = Request.Url.AbsoluteUri.Split('?')[0];
                GoogleConnect.API = EnumAPI.Drive;
    
                if (string.IsNullOrEmpty(Request.QueryString["code"]))
                    GoogleConnect.Authorize("https://www.googleapis.com/auth/drive.file");
                
                if (flagUpdateFile == 0)
                    UploadFile();
            }
    
            protected HttpPostedFile ConstructHttpPostedFile(byte[] data, string filename, string contentType = null)
            {
                // Get the System.Web assembly reference
                Assembly systemWebAssembly = typeof(HttpPostedFileBase).Assembly;
                // Get the types of the two internal types we need
                Type typeHttpRawUploadedContent = systemWebAssembly.GetType("System.Web.HttpRawUploadedContent");
                Type typeHttpInputStream = systemWebAssembly.GetType("System.Web.HttpInputStream");
    
                // Prepare the signatures of the constructors we want.
                Type[] uploadedParams = { typeof(int), typeof(int) };
                Type[] streamParams = { typeHttpRawUploadedContent, typeof(int), typeof(int) };
                Type[] parameters = { typeof(string), typeof(string), typeHttpInputStream };
    
                // Create an HttpRawUploadedContent instance
                object uploadedContent = typeHttpRawUploadedContent
                    .GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, uploadedParams, null)
                    .Invoke(new object[] { data.Length, data.Length });
    
                // Call the AddBytes method
                typeHttpRawUploadedContent
                    .GetMethod("AddBytes", BindingFlags.NonPublic | BindingFlags.Instance)
                    .Invoke(uploadedContent, new object[] { data, 0, data.Length });
    
                // This is necessary if you will be using the returned content (ie to Save)
                typeHttpRawUploadedContent
                    .GetMethod("DoneAddingBytes", BindingFlags.NonPublic | BindingFlags.Instance)
                    .Invoke(uploadedContent, null);
    
                // Create an HttpInputStream instance
                object stream = (Stream)typeHttpInputStream
                    .GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, streamParams, null)
                    .Invoke(new object[] { uploadedContent, 0, data.Length });
    
                // Create an HttpPostedFile instance
                HttpPostedFile postedFile = (HttpPostedFile)typeof(HttpPostedFile)
                    .GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, parameters, null)
                    .Invoke(new object[] { filename, contentType, stream });
    
                return postedFile;
            }
    
    
            protected void UploadFile()
            {
                HttpFileCollection MyFileCollection = Request.Files;
    
                foreach (string dir in dirs)
                {
                    byte[] fileData = System.IO.File.ReadAllBytes(dir);
                    string fileName = Path.GetFileName(dir);
                    flagUpdateFile = 1;
                    //Content Type is null
                    Session["File"] = ConstructHttpPostedFile(fileData, fileName); 
    
                    //Token return from Google API
                    if (!string.IsNullOrEmpty(Request.QueryString["code"]) && flagUpdateFile == 1)
                    {
                        string code = Request.QueryString["code"];
                        string json = GoogleConnect.PostFile(code, (HttpPostedFile)Session["File"], "");
                        flagUpdateFile = 0;
                        System.IO.File.Delete(dir);
                        
                    }
    
                    if (Request.QueryString["error"] == "access_denied")
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Access denied.')", true);
                        Console.Write("Access denied,check your Authorized redirect URIs!");
                    }
    
                    HttpContext.Current.Session.Remove("File");
                    HttpContext.Current.Session.Abandon();
    
                }
            }
    
    
        }
    }
