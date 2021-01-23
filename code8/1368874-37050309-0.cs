    [System.Web.Services.WebMethod(BufferResponse=false)]
    public static async Task<bool> getLogin(string username, string password)
    {
        Login login = new Login();
        Task<bool> loginVerify = login.verifyLogin(username, password);
        return await loginVerify;
    }
    
    public class Login
    {
        public async Task<bool> verifyLogin(string username, string password)
        {
            return true;
        }
    }
