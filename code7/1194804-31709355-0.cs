        public string Error
        {
           get
              {
                   return null;
              }
        }
 
        public string this[string name]
        {
            ValidateProperty(name);
        }
    public override void ValidateProperty(string propertyName)
    	{
    		Tracer.LogValidation("INotifyDataErrorInfo.ValidateProperty called. Validating " + propertyName);
    		switch (propertyName)
    		{
    			case "x":
    				{
    					ValidateNonNegative(x, "x");
    					ValidateMandatory(x, "x");
    				}
				break;
			case "y":
				{
					ValidateNonNegative(y, "y");
					ValidateMandatory(y, "y");
				}
				break;
		}
		if (String.IsNullOrEmpty(propertyName))
		{
			Tracer.LogValidation("No cross-property validation errors.");
		}
	  }
