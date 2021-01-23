    [DataContract]
    public class AmazonSNSMessage
    {
        [DataMember(Name = "default")]
        public string Default { get; set; }
        [DataMember(Name = "APNS_SANDBOX")]
        public string APNSSandbox { get; set; }
        [DataMember(Name = "APNS")]
        public string APNSLive { get; set; }
        public AmazonSNSMessage(string notificationText, NotificationEvent notificationEvent, string objectID)
        {
            Default = notificationText;
            var apnsSerialized = JsonConvert.SerializeObject(new APNS
            {
                APS = new APS { Alert = notificationText },
                Event = Enum.GetName(typeof(NotificationEvent), notificationEvent),
                ObjectID = objectID
            });
            APNSLive = APNSSandbox = apnsSerialized;
        }
        
        public string SerializeToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    [DataContract]
    public class APNS 
    {
        [DataMember(Name = "aps")]
        public APS APS { get; set; }
        [DataMember(Name = "event")]
        public string Event { get; set; }
        [DataMember(Name = "objectID")]
        public string ObjectID { get; set; }
    }
    [DataContract]
    public class APS
    {
        [DataMember(Name = "alert")]
        public string Alert { get; set; }
    }
