    public CustomResponse Get()
    {
        CustomResponse response = new CustomResponse();
        
        // some work
        response.TestProperty1 = "Test Value 1";
        response.TestProperty2 = "Test value 2";
    
        return response;
    }
