    using Microsoft.Office.InfoPath;
    using System.Windows.Forms;
    using mshtml;
    using System;
    using System.Xml;
    using System.Xml.XPath;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    using System.Net;
    using System.Web;
    using System.Web.Script.Serialization;
    using System.ServiceModel.Web;
    using Newtonsoft.Json;
    
    
    namespace sms_form1
        {
        public class Contact
        {
            public string id { get; set; }
            public string name { get; set; }
            public string number { get; set; }
        }
    
        public class Success
        {
            public string id { get; set; }
            public string device_id { get; set; }
            public string message { get; set; }
            public string status { get; set; }
            public string send_at { get; set; }
            public string queued_at { get; set; }
            public string sent_at { get; set; }
            public string delivered_at { get; set; }
            public string expires_at { get; set; }
            public string canceled_at { get; set; }
            public string failed_at { get; set; }
            public string received_at { get; set; }
            public string error { get; set; }
            public string created_at { get; set; }
            public Contact contact { get; set; }
        }
    
        public class Errors
        {
            public List<String> device { get; set; }
        }
    
        public class Fail
        {
            public string email { get; set; }
            public string password { get; set; }
            public string device { get; set; }
            public string number { get; set; }
            public string message { get; set; }
            public Errors errors { get; set; }
        }
    
        public class Result
        {
            public List<Success> success { get; set; }
            public List<Fail> fails { get; set; }
        }
    
        public class RootObject
        {
            public bool success { get; set; }
            public Result result { get; set; }
        }
    
        public partial class FormCode
        {
            public void InternalStartup()
            {
                EventManager.FormEvents.Submit += new SubmitEventHandler(FormEvents_Submit);
            }
    
            public void FormEvents_Submit(object sender, SubmitEventArgs e)
            {
    
                var UriBuilder = new UriBuilder("http://smsgateway.me/api/v3/messages/send/");
                var parameters = HttpUtility.ParseQueryString(string.Empty);
                parameters["email"] = MainDataSource.CreateNavigator().SelectSingleNode("/my:myFields/my:email", NamespaceManager).Value;
                parameters["password"] = MainDataSource.CreateNavigator().SelectSingleNode("/my:myFields/my:password", NamespaceManager).Value;
                parameters["device"] = MainDataSource.CreateNavigator().SelectSingleNode("/my:myFields/my:device", NamespaceManager).Value; ;
                parameters["number"] = MainDataSource.CreateNavigator().SelectSingleNode("/my:myFields/my:MobileNumber", NamespaceManager).Value;
                parameters["message"] = MainDataSource.CreateNavigator().SelectSingleNode("/my:myFields/my:SMS_TO_BE_SENT", NamespaceManager).Value; ;
                UriBuilder.Query = parameters.ToString();
                //UriBuilder.Fragment = "some_fragment";
    
                Uri finalUrl = UriBuilder.Uri;
                var request = WebRequest.Create(finalUrl);
    
                // Get the response.
                WebResponse result = request.GetResponse();
    
    
    
    
    
                // Get the stream containing content returned by the server.
                Stream dataStream = result.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
    
    
                var successRoot = JsonConvert.DeserializeObject<RootObject>(responseFromServer);
    
               var isSuccess = successRoot.result.success != null && successRoot.result.success.Count > 0;
              var isFail = successRoot.result.fails != null && successRoot.result.fails.Count > 0;
                
              if (isSuccess)
              {
                  var id = successRoot.result.success.First().id;
                  var message = successRoot.result.success.First().message;
                 // Display the content.
    
                 string value = Convert.ToString(id);
                 string value1 = Convert.ToString(message);
                  System.Windows.Forms.MessageBox.Show("SMS "+value+" "+value1+" Sent SuccessFully" );
                         }
              else
              {
                  //var messagefail = successRoot.result.fails.First().device;
                  //string value = Convert.ToString(messagefail);
    
                  System.Windows.Forms.MessageBox.Show("SMS Could Not Be Sent. Check Device");
                         }
    
               // Clean up the streams.
                reader.Close();
                dataStream.Close();
                result.Close();
    
    
            }
        }
    }
                
