    #region Namespaces
    using System.Windows.Forms;
    using Microsoft.SharePoint.Client;
    using System.Security;
    using System.Net;
    using Microsoft.SharePoint;
    using System.IO;
    using Microsoft.SqlServer.Dts.Runtime;
    using System;
    using System.Data;
    #endregion
    
    namespace ST_14e7d12d30c54d54a1eaa0bfa5961c5b
    {
        
        [Microsoft.SqlServer.Dts.Tasks.ScriptTask.SSISScriptTaskEntryPointAttribute]
        public partial class ScriptMain : Microsoft.SqlServer.Dts.Tasks.ScriptTask.VSTARTScriptObjectModelBase
        {
            
            
    
            public static class Utils
            {
    
                public static SharePointOnlineCredentials GetO365Credentials(string userName, string passWord)
                {
                    SecureString securePassWord = new SecureString();
    
                    foreach (char c in passWord.ToCharArray()) securePassWord.AppendChar(c);
    
                    SharePointOnlineCredentials credentials = new SharePointOnlineCredentials(userName, securePassWord);
    
                    return credentials;
    
                }
            }
    
            public void Main()
            {
    
                try
                {
    
    				//Set the Sharepoint URL (Till the folder that the files needs to be uploaded)
                    string siteUrl = "https://AAAAAAAAA.sharepoint.com/BBBBBBBB/CCCCCCCC";
    
                   
    			   //FQDN source file details passing from the package 
                    string filePath = @Dts.Variables["User::SharePoint_SrcFile"].Value.ToString();
                    
    				//Destination File Path (inclueds file name and full share point adddress)
                    string DestinationfilePath = @Dts.Variables["User::Sharepoint_DestLocation"].Value.ToString();
    
                    //loging the processing file
                    bool fireAgain = true;
                    Dts.Events.FireInformation(0,"","Source File Processing:" + filePath + " || Share Point Dest:" + DestinationfilePath,"", 0,ref fireAgain);
    
    				//Setting the library name (can find from the share point site)
                    string libraryName = "Documents";
    
                    ClientContext ctx = new ClientContext(siteUrl);
    
                    ctx.RequestTimeout = 1000000;
    				
    				//Retriveng user name and password from project parameeter (Password set as sensitive)
                    string sharepointusername = @Dts.Variables["$Project::sSharePointUserName"].Value.ToString();
                    string sharepointPassword = @Dts.Variables["$Project::sSharePointPassword"].GetSensitiveValue().ToString();
    
                    
    				//Authenticating (using the sharepoint client installed)
                    ctx.Credentials = Utils.GetO365Credentials(sharepointusername, sharepointPassword);
    
                    Web web = ctx.Web;
                    ctx.Load(web, a => a.ServerRelativeUrl);
    
                    List docs = web.Lists.GetByTitle(libraryName);
    
                    ctx.ExecuteQuery();
    
    
                    using (FileStream fs = new FileStream(filePath, FileMode.Open))
    
                    {
    
                        FileCreationInformation flciNewFile = new FileCreationInformation();
    
                        flciNewFile.ContentStream = fs;
    
                        flciNewFile.Url = Path.GetFileName(filePath);
    
                        flciNewFile.Overwrite = true;
    
                        //Upload URL
                       
                        flciNewFile.Url = DestinationfilePath.ToString() ;
                        
    
                        Microsoft.SharePoint.Client.File uploadFile = docs.RootFolder.Files.Add(flciNewFile);
    
                        //ctx.Load(uploadFile);
                        uploadFile.ListItemAllFields["Title"] = "sharepoint";
                        uploadFile.ListItemAllFields.Update();
    
                        ctx.ExecuteQuery();
    
                }
                
                
                
    
            }
                catch (Exception ex)
                {
                    Dts.Events.FireError(0,"", ex.Message, "", 0);
                }
               
    
            }
    
            #region ScriptResults declaration
           
            enum ScriptResults
            {
                Success = Microsoft.SqlServer.Dts.Runtime.DTSExecResult.Success,
                Failure = Microsoft.SqlServer.Dts.Runtime.DTSExecResult.Failure
            };
            #endregion
