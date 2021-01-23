    public interface IAdministrator 
    {
        string SpecificAdministratorAttribute { get; set;}
    }
    public class OtherKindOfAdministrator: User, IAdministrator
