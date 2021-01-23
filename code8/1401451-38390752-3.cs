    // Here you will be telling the AppServer to use MyAppSession as the default AppSession class and the MyRequestInfo as the defualt RequestInfo
    public class MyAppServer : AppServer<MyAppSession, MyRequestInfo>
    {
    // Here in constructor telling to use MyReceiveFilter and MyRequestInfo
        protected MyAppServer() : base(new DefaultReceiveFilterFactory<MyReceiveFilter, MyRequestInfo>())
        {
            NewRequestReceived += ProcessNewMessage;
        }
        // This method/event will fire whenever a new message is received from the client/session
        // After passing through the filter
        // the requestInfo will contain the ASCII and HEX strings
        private void ProcessNewMessage(MyAppSession session, MyRequestInfo requestinfo)
        {
            session.ClientKey = SessionCount;
            // Here you can access the HEX, ASCII strings that where generated in the MyReceiveFilter.Filter() Method.
            Console.WriteLine(requestinfo.RawHex);
            // Do whatever you want
            session.Send("Hello World");
            session.Close();
        }
    }
