    public partial class Form1 : Form
    {
        public string Result = "";
    
        MyServer server = new MyServer();
        AutoResetEvent res = new AutoResetEvent(false);
    
        public Form1()
        {
            InitializeComponent();
    
            server.RecieveMessage += new MyServer.RecieveMessageEventHandler(server_RecieveMessage);
        }
    
        void server_RecieveMessage(object sender, string message)
        {
            Result = message;
            res.Set();
        }
    
    
        public string SendCommand(string Command)
        {        
            server.Send(Command);
            res.WaitOne();
    
            //wait untill RecieveMessage event raised
    
    
            //process Data is recieved
    
            server.Send(AnotherCommand);
            res.WaitOne();    
            //wait untill RecieveMessage event raised
    
    
            //process Data is recieved
    
            ....
    
                //till i get what i want
            return Result;
        }
