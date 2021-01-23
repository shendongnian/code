    //model
    namespace Web.Models
    {
        using Application.Models;
       
        public class ChangeSet
        {
            public UserChangeRequest[] ChangeRequests { get; set; }
     
            public string Comment { get; set; }
        }
    }
