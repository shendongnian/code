    public class LoginDto
    {
     public string UserMail { get; set; }
     public string Password { get; set; }
    }  
 
    [HttpPut]
    public HttpResponseMessage PutLogin(LoginDto loginDto)
    {
      // use loginDto
    }
