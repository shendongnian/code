    // the string is allocated immediately.
    string test = string.Empty;
    // the client will execute the lambda when a message arrives.
    client.OnMessage(message =>
    {
        // this is executed when a message arrives.
        test = String.Format("Message body: {0}", message.GetBody<String>());
    
        // this will output the message when a message arrives, and 
        // the lambda expression executes.
        Console.WriteLine("test: "+test); //outputs "test: "
    });
    // this line of code runs immediately, before the message arrives.
    Console.WriteLine("test: "+test); //outputs "test: "
