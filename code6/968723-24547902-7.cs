    public class User : BaseClass
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override String Save(){
            s = base.Save(); //recall base.Save() as long as its not the topmost-entity
            //attach Username, password, firstname, lastname
            return s;
        }
    }
    
    public class BaseClass
    {
        public int Id { get; set; }
        
        public virtual String Save()
        {
           String s = "";
           //attach id to s
           return s; 
         }
    }
