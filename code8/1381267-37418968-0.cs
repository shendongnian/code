    namespace ManyToManyToOneMessage
    {
        public partial class Message 
        {
            public Guid Id { get; set; }
            public virtual ICollection<Response> Responses { get; set; }
            public virtual ICollection<Administrator> Administrators { get; set; }
        }
    
        public partial class Message
        {
            public Request Request {get; set;}
            public Administrator Administrator { get; set;}
        }
    
        public class Response
        {
            //Place response formatting here.
        }
    
        public class Request
        {
            //Place request formatting here.
        }
      
        public class Administrator  {
            public Guid Id { get; set; }
            public virtual ICollection<Request> Requests { get; set; }
            public virtual ICollection<Response> Responses { get; set; }
        }   
    }
