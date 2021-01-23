    static void Main(string[] args)
    {
        CreateQueue(".\\exampleQueue", false);
        using (var queue = new MessageQueue(".\\exampleQueue"))
        {
            queue.ReceiveCompleted += MyReceiveCompleted;
            queue.BeginReceive();
            // here you have to insert code to block the 
            // execution of the Main method.
            // Something like:
            while(Console.ReadLine() != "exit")
            {
                // do nothing
            }
        }
    }
 
