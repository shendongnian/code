    public class EmployeeViewModel
    {
    	public string Name { get; set; }
    
    	public string Email { get; set; }
    
        [RequiredIf("IsRequired", true, ErrorMessage = "Feedback is Required!")]
        public string FeedBack { get; set; }
    	
    	public string Role {get; set;}
    	
    	public int Experience {get; set;}
    	
    	public bool IsRequired
    	{
    		get
    		{
    			Role.Equals("Manager") && Experience == 121 ||
    			Role.Equals("Developer") && Experience == 4
    		}
    	}
    }
