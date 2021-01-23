    [HttpPost]
            public bool Create(DoSomething model)
            {
                return true
            }
 
    public class DoSomething 
        {
            public int UserId{ get; set; }
            public string UserName{ get; set; }
            public string Email{ get; set; }
        }
