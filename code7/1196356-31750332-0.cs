    public class Type
    {
         public string Value {get;set;}
         public ICollection<Status> Statuses {get;set;}
    {
    
    public class Status
    {
          public string Value {get;set;}
          public int? ParentStatusId {get;set;}
          public Status ParentStatus {get;set;}
          public ICollection<Status> ChildStatuses {get;set;}
    }
