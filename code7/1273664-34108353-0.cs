     public class Client
     {
       public long Id { get; set; }
       public virtual IList<Solution> Solutions { get; set; }
     }
     public class Solution
     {
       public long Id { get; set; }
       public long? ClientId { get; set; }
       public virtual Client Client { get; set; }
     }     
     
