      using System;
      using System.Collections.Generic;
      using System.Linq;
      using System.Text;
      using System.Threading.Tasks;
      using System.Configuration;
      using OpenQA.Selenium;
      using OpenQA.Selenium.Chrome;
      using Logger;
      using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
      using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
      using Microsoft.VisualStudio.Services.Common;
      using Microsoft.VisualStudio.Services.WebApi.Patch.Json;
      using Microsoft.VisualStudio.Services.WebApi.Patch;
      using Microsoft.VisualStudio.Services.WebApi;
      using System.Net.Http.Headers;
      using System.Net.Http;
      using Newtonsoft.Json;
      using System.IO;
      using System.Collections;
      using Newtonsoft.Json.Linq;
    
    namespace CreateABugInVSOProgrammatically
        {
    
    static class ReportBug
        {
        static string _uri;
        static string _personalAccessToken;
        static string _project;
        static string PathOfAttachment;
        public static List<Params> ListParams;
        static ReportBug()
        {
            _uri = ConfigurationManager.AppSettings["DynamicsUrl"];
            _personalAccessToken = GetDecodedToken(ConfigurationManager.AppSettings["PAT"]);
            _project = ConfigurationManager.AppSettings["ProjectName"];            
        }       
        private static List<Params> GetAllField(Fields fields)
        {
            List<Params> list = new List<Params>();
            list.Add(new Params() { Path = "/fields/System.Title", Value = fields.Title });
            list.Add(new Params() { Path = "/fields/Microsoft.VSTS.TCM.ReproSteps", Value = fields.ReproSteps });
            list.Add(new Params() { Path = "/fields/Microsoft.VSTS.Common.Priority", Value = fields.Priority });
            list.Add(new Params() { Path = "/fields/Microsoft.VSTS.Common.Severity", Value = fields.Severity });
            list.Add(new Params() { Path = "/fields/Microsoft.VSTS.Common.Issue", Value = fields.Issue });
            list.Add(new Params() { Path = "/fields/Microsoft.VSTS.MPT.Source", Value = fields.Source });
            list.Add(new Params() { Path = "/fields/System.State", Value = fields.State });
            list.Add(new Params() { Path = "/fields/Microsoft.VSTS.Common.HowFoundCategory", Value = fields.HowFoundCategory });
            list.Add(new Params() { Path = "/fields/Microsoft.VSTS.Common.Regression", Value = fields.Regression });
            list.Add(new Params() { Path = "/fields/System.AttachedFileCount", Value = fields.AttachedFileCount });
            return list;
        }
        public static WorkItem CreateBugInVSO(IWebDriver driver, Fields fields)
        {
            try
            {
            PathOfAttachment = ScreenShotCapture.CaptureScreenShotOfCurrentBrowser(driver ,fields.PathOfFile);
            ListParams.AddRange(GetAllField(fields));
            Uri uri = new Uri(_uri);
            string personalAccessToken = _personalAccessToken;
            string project = _project;
            VssBasicCredential credentials = new VssBasicCredential("", _personalAccessToken);
            AttachmentReference attachment = UploadAttachment(uri, credentials);
            ListParams.Add(new Params()
            {
                Path = "/relations/-",
                Value = new
                {
                    rel = "AttachedFile",
                    url = attachment.Url,
                    attributes = new { comment = fields.Comments }
                }
            });
            JsonPatchDocument patchDocument = new JsonPatchDocument();
            //add fields and their values to your patch document  
            foreach (var item in ListParams)
            {
                patchDocument.Add(
                              new JsonPatchOperation()
                              {
                                  Operation = Operation.Add,
                                  Path = item.Path,
                                  Value = item.Value,
                              }
                          );
            }
            VssConnection connection = new VssConnection(uri, credentials);
            WorkItemTrackingHttpClient workItemTrackingHttpClient = connection.GetClient<WorkItemTrackingHttpClient>();
            
                WorkItem result = workItemTrackingHttpClient.CreateWorkItemAsync(patchDocument, project, "Bug").Result;
                return result;
            }
            catch (AggregateException ex)
            {
                Log.Logger.Error("Error occurred while Creating bug in VSO" + ex);
                return null;
            }
        }
        // This method will upload attachment and return url for file and Id
        private static AttachmentReference UploadAttachment(Uri uri, VssBasicCredential credentials)
        {
            try
            {
                VssConnection _tpc = new VssConnection(uri, credentials);
                WorkItemTrackingHttpClient workItemTrackingHttpClient = _tpc.GetClient<WorkItemTrackingHttpClient>();
                AttachmentReference attachment = workItemTrackingHttpClient.CreateAttachmentAsync(PathOfAttachment).Result;
                // Save the attachment ID for the "download" sample call later           
                return attachment;
            }
            catch (Exception ex)
            {            
                Log.Logger.Error("Error occurred while Attaching Attachment in bug" + ex);
                return null;
            }
        }
           
        }
    }
    public class Params
    {
        public string Path { get; set; }
        public object Value { get; set; }
    }
    //This class contain all the fields that are mandatory to create a bug
    public class Fields
    {
        public string Title { get; set; }
        public string Priority { get; set; }
        public string ReproSteps { get; set; }
        public string Severity { get; set; }
        public string Issue { get; set; }
        public string Source { get; set; }
        public string State { get; set; }
        public string HowFoundCategory { get; set; }
        public string Regression { get; set; }
        public int AttachedFileCount { get; set; }
        public string Comments { get; internal set; }
        public string PathOfFile { get; internal set; }
    }
