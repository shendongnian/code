    public class DomainObject
    {
        public int Id{ get; set; }
        public string Name {get;set; }
    }
    public class BusinessLogic
    {
        public void DoSomethingBusinessLike(DomainObject do)
        {
           //stuff happens
        }
     }
