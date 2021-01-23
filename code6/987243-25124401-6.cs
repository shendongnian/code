    [DataContract(Name="text_message",Namespace = "")]
    public class SMSData
    {
        [DataMember]
        public int id { set; get; }
        [DataMember]
        public string message { set; get; }
        [DataMember]
        public int time { set; get; }
        [DataMember]
        public Message_phone message_phone { set; get; }
        // for easy access to cellphone
        public string cellphone 
        {
            get 
            {
                 return message_phone!=null?message_phone.cellphone:null;
            }
        }
    }
    
    [DataContract(Name="message_phone",Namespace = "")]
    public class Message_phone
    {
        [DataMember]
        public string cellphone { set; get; }
    }
