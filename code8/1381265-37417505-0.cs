    public class Request
    {
      public int RequestId { get; set; }
      public virtual ICollection<Response> Responses { get; set; }
      public virtual ICollection<Administrator> Administrators { get; set; }
    }
    public class Response
    {
    public int ResponseId { get; set; }
    [ForeignKey("Request")]
    public virtual int? RequestID {get;set;}
    public virtual Request Request{get;set;}
    [ForeignKey("Administrator ")]
    public virtual int? AdministratorID {get;set;}
    public virtual Administrator Administrator { get; set; }
    }
    public class Administrator
    {
    public int AdministratorId { get; set; }
    public virtual ICollection<Request> Requests { get; set; }
    public virtual ICollection<Response> Responses { get; set; }
    }
