    [DataContract(Name="text_message",Namespace = "")]
    public class SMSData
    {
        [DataMember(Order =1)]
        public int id { set; get; }    
        [DataMember(Order = 2)]
        public string message { set; get; }
        [DataMember(Order = 3)]
        public int time { set; get; }
        [DataMember(Order = 4)]
        public Message_phone message_phone { set; get; }
       
         // for easy access to cellphone
            public string cellphone {
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
