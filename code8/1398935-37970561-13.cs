    public class MyUser: IMyUser {
       // ommited for abbrev.       
    }
    
    public interface IMyUser: IIdentity {
        int Id { get; set; }
        int? CompanyId { get; set; }        
    }
