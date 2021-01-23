    public class UserandProfile
    {
       // Properties
       public Users_AboutMe objAMe { get; set; }
       public Users_Education objEdu { get; set; }
       public Users_Interests objInterests { get; set; }
       
       // Constructor
       public UserandProfile()
       {
          objAMe = new Users_AboutMe();
          objEdu = new Users_Education();
          objInterests = new Users_Interests();
       }
    }
