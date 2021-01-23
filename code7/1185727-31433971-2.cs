    public class A
    {
       string FirstName{get;set;}
       string LastName{get;set;}
       List<Object> MyItems{get;set;}
       string Info {get { return MyItems.Count > 0 ? "items exist" : "no items"; }}
    }
