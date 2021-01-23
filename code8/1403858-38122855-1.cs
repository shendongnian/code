    // keep a list if you need one.
    var bag = new ConcurrentBag<string>();
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
 
        // you could add the message to a list here.
        bag.Add(message.GetBody<string>());
    });
    // this line of code runs immediately, before the message arrives.
    Console.WriteLine("test: "+test); //outputs "test: "
