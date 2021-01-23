    var validationResult = new ValidationResult();
    if (props.ContainsKey("primary site owner"))
    {
       owner = props["primary site owner"].ToString();
    }
    else
       validationResult.MessageList.Add("error with site owner");
    if(props.ContainsKey("primary site owner Email"))
    {
       owneremail = props["primary site owner Email"].ToString();
    }
    else 
       validationResult.MessageList.Add("error with email");
    ...
    if(!validationResult.Validated)
      throw new Exception(validationResult.Message);
    // or Console.WriteLine(validationResult.Message)
          
