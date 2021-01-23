    public class <TheClassInDLL>
    {
        public event EventHandler<MyEventArgs> DataEventCalled;
        // SNIP: All the other code that leads to tcp1_Data being called
        ...
        // The event handler that's called by some code in the class
        public void tcp1_Data(object sender, Dart.Sockets.DataEventArgs e)
        {
            Tcp tcp = (Tcp)sender;
            // Note: LOCAL variable
            string myresponse = "Socket Connection" + tcp.Tag.ToString() + " replied : " + e.Data.ToString();
            // Call the new event here
            if (DataEventCalled != null)
                DataEventCalled(this, new MyEventArgs(myresponse));
            tcp.Close();
        }
        // We use this class to pass arguments to the event handler
        public class MyEventArgs : EventArgs
        {
            public MyEventArgs(string response)
            {
                this.Response = response;
            }
 
            public string Response
            {
                get;
                private set;
            }
        }
    }
