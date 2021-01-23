    public class User
    {
        // from table TM_USER 
        public int Id { get; set; }
        public string Username { get; set; }
        public string Key { get; set; }
    
       
        public string Forename { get; set; }
        public string Surname { get; set; }
    
        public bool IsApproved { get; set; }
    }
