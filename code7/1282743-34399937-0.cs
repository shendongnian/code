    public class Test
    {
    	public string Id {get; set;}
    	public string Email {get; set;}
    	public string OldPassword {get; set;}
    	public string NewPassword {get; set;}
    	public bool IsLockoutEnabled {get; set;}
    }
    public async Task<HttpResponseMessage> Put(Test entity)
    {
    	.....
    }
