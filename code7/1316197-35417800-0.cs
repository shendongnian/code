    class Response()
    {
         public List<string> errors {get;set;}
    }
    public Response DoStuff()
    {
        var response = new Response();
        int result;
        if (DeviceSettings == null)
            response.errors.Add("Not Initialized");
        if (!Serial.IsNotEmpty())
            response.errors.Add("The serial number is empty.");
        if (!int.TryParse(Serial, out result))
            response.errors.Add("Argument out of range");
        // check your response errors, return if necessary
        //do stuff
        return response;
    }
