    void Main()
    {
    	var test = new Test();
    	Validator.ValidateObject(test, new ValidationContext(test));	
    }
    
    public class Test 
    {
    	private string _name;
    	[Required(AllowEmptyStrings = false, ErrorMessage = "The Name cannot be empty. Please correct.")]
        public String Name
        {
            get { return _name; }
            set 
            {
                String setValue = Regex.Replace(value, @"^\d+", "");
                setValue = Regex.Replace(setValue, @"[^a-zA-Z0-9_]+", "_");
                _name = setValue;
            }
        }
    }
