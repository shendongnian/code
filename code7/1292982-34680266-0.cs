    public class Registrar
    {
       public string QUID_Disp { get; set; }
       public string QU_User_Disp { get; set; }
       public string Admin_User_Disp { get; set; }
       public string Reg_User_Disp { get; set; }
       public List<Registrar> Events { get; set; }
    
       public YourViewModel()
       {
         Events = new List<Registrar>();
       }
    }
