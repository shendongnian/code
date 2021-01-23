    // Add reference to System.ComponentModel.DataAnnotations if necessary
    using System.ComponentModel.DataAnnotations;
    
    public void InsertEmployee(string fname, string lname, string alias, 
                               string contact, string address, string company,
                               string bdate, string email) {
    	ValidateEmployee(fname,lname,alias,contact,address,company,bdate,email);
    	obj.InsertEmployee(fname,lname,alias,contact,address,company,bdate,email);
    }
    
    private void ValidateEmployee(string fname, string lname, string alias, 
                                  string contact, string address, string company,
                                  string bdate, string email) {
    	var validationErrors = new List<string>();
    	if (string.IsNullOrEmpty(fname))
    		validationErrors.Add("First name is a required field.");
    	if (string.IsNullOrEmpty(lname))
    		validationErrors.Add("Last name is a required field.");
    	// Etc... add other validations
    	
    	if (validationErrors.Any()) {
    		throw new ValidationException(string.Join(" ", validationErrors));
    	}
    }
