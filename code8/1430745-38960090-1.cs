    // mainviewmodel
    Messenger.Default.Send(new MyMessage(myObj));
    // otherviewmodel
    Messenger.Default.Register<MyMessage>(this, message => 
    {
        /* do something with message.MyObj */
    });
    // mymessage
    public class MyMessage : MessageBase
    {
        ...
        public MyObj MyObj { get; set; }
    }
