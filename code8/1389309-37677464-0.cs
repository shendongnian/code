    // Sends a message with a user object from ViewModel 1
    User user = new user { Name = "testName" };
    Messenger.Default.Send(user);
   
    // Receive the user object in ViewModel 2
    Messenger.Default.Register<User>(this, (user) =>
    {
        // use "user" object
    });
