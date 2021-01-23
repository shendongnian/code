     [ServiceContract(Namespace = "http://schemas.microsoft.com/TeamFoundation/2005/06/Services/Notification/03")]
        public interface ITfsNotificationService
        {
            [OperationContract(Action = "http://schemas.microsoft.com/TeamFoundation/2005/06/Services/Notification/03/Notify", Name = "Notify", ReplyAction = "http://schemas.microsoft.com/TeamFoundation/2005/06/Services/Notification/03/ResponstToNotify")]
            [XmlSerializerFormat(Style = OperationFormatStyle.Document)]
            void Notify(string eventXml, string tfsIdentityXml, SubscriptionInfo SubscriptionInfo);
        }
    
        [ServiceBehavior(Namespace = "http://schemas.microsoft.com/TeamFoundation/2005/06/Services/Notification/03")]
        public class Service1 : ITfsNotificationService
        {
            public void Notify(string eventXml, string tfsIdentityXml, SubscriptionInfo SubscriptionInfo)
            {
                throw new NotImplementedException();
            }
        }
