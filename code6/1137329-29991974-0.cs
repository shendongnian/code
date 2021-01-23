    public class MyEventArgs : EventArgs
    {
        public string msg="";
        public MyEventArgs(string s){
           msg=s;
        }
    }
    // Delegate declaration. 
    public delegate void MyEventHandler(object sender, MyEventArgs e);
    public event MyEventHandler myHandler;
    protected virtual void OnUpdate(MyEventArgs e)
    {
        MyEventHandler handler = myHandler;
        if (handler != null)
        {
           // Invokes the delegates.
           handler(this, e);
        }
    }
