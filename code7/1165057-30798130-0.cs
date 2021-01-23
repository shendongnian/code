    //in MyProject.Core which is shared
    class User
    {
         public int Id { get; set; }
         public string UserName { get; set; }
         public string Password { get; set; }
    }
    //in MyProject.WcfApi which has wcf services for other teams
    [DataContract]
    class UserOutput
    {
         [DataMember]
         public int Id { get; set; }
         [DataMember]
         public string UserName { get; set; }
         //no password property here
    }
    //in MyProject.WebApi which has some web apis for js
    class UserOutput
    {
        [MyJsonRelatedAttribute]
        public int Id { get; set; }    
    }
