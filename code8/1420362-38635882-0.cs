    public JsonResult SearchClient(modalclass model)
       {
       string FirstName=model.FirstName;
       string lastname=model.Lastname;
        }
    public class modalclass 
    {
    public string FirstName{get;set};
    public string LastName{get;set};
    public int Mobile {get;set};
    }
