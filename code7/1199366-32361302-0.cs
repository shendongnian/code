    // Declare the options for the call to the API
    FacebookGetUserOptions options = new FacebookGetUserOptions("me") {
        Fields = "name,email,gender"
    };
    
    // Make the call to the API
    FacebookUserResponse response = service.Users.GetUser(options);
