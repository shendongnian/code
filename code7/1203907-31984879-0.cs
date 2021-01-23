    [DataContract]
    public class User
    {
        // This member is serialized.
        [DataMember]
        string FullName;
		
        // This is not serialized because the DataMemberAttribute 
        // has not been applied.
        private string MailingAddress;
    
    }
	
