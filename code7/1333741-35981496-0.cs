    public interface ILoginManager{
       void Authenticate(string username, string password);
    
       void IsAuthenticated{ get;}
    }
