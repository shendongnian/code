      public class Employees
{
   
    public string FName {get;set;}
    public string LName {get;set;}
    public string Position {get;set;}
    public string Email {get;set;}
    [Display(Name = "Full Name")]
    public string FullName
    {
        get
        {
            return LName + ", " + FName;
        }
    }
