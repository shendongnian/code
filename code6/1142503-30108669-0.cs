    public class MyEventArgs : EventArgs
    {
       //add properties you want to send to the UI here.
    }
    public delegate void ProcessedEventHandler(object sender, MyEventArgs e);
    
