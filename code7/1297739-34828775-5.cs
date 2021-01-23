    ClassThatContainsSelectMethod yourDBObject = new ClassThatContainsSelectMethod();
    List<User> users = yourDBObject.Select();
    
    foreach (User user in users) 
    {
        Console.WriteLine(user.Id, user.Test, user.Balance); 
    }
