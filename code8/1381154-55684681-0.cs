     public class PushNotification
     {
         private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            // firebase
         private static Uri FireBasePushNotificationsURL = new Uri("https://fcm.googleapis.com/fcm/send");
         private static string ServerKey = ConfigurationManager.AppSettings["FIREBASESERVERKEY"];
       
         public static async Task<bool> SendPushNotification(List<SendNotificationModel> notificationData)
         {
             try
             {
                 bool sent = false;         
                 foreach (var data in notificationData)
                 {
                     var messageInformation = new Message()
                     {
                         notification = new Notification()
                         {
                             title = data.Title,
                             text = data.Message,
                             ClickAction = "FCM_PLUGIN_ACTIVITY"
                          },
                          data = data.data,
                          priority="high",
                          to =data.DeviceId
                     };
                     string jsonMessage = JsonConvert.SerializeObject(messageInformation);
                      
                     //Create request to Firebase API
                     var request = new HttpRequestMessage(HttpMethod.Post, FireBasePushNotificationsURL);
    
                     request.Headers.TryAddWithoutValidation("Authorization", "key=" + ServerKey);
                     request.Content = new StringContent(jsonMessage, Encoding.UTF8, "application/json");
    
                     HttpResponseMessage result;
                     using (var client = new HttpClient())
                     {
                         result = await client.SendAsync(request);
                         sent =  result.IsSuccessStatusCode;
                     }             
                 }
    
                    return sent;
             }
             catch(Exception ex)
             {
                 Logger.Error(ex);
                 return false;
              }
        }
     }
