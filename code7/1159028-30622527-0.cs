    public class Login : ICustomer
    {
        public string Name { get; set; }
        public string Pdw { get; set; }
    }
    
    interface ICustomer
    {
        string Name { get; set; }
        string Pdw { get; set; }
    }
    
    var loginModel = new Login();
    
    //then access loginModel.Name & loginModel.Pdw
