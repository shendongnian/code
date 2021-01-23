    public class Greeter : ReceiveActor
    {
        public Greeter()
        {
            Receive<Greet>(greet =>
            {
                // when message arrives, we publish it on the event stream 
                // and send response back to sender
                Context.System.EventStream.Publish(greet.Who + " sends greetings");
                Sender.Tell(new GreetBack(Self.Path.Name));
            });
        }
    }
