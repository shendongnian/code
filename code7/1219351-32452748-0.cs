     public partial class Form1 : Form
     {
     public string Result = "";
     MyServer server = new MyServer();
    public Form1()
    {
        InitializeComponent();
        server.RecieveMessage += new MyServer.RecieveMessageEventHandler(server_RecieveMessage);
    }
    void server_RecieveMessage(object sender, string message)
    {
        Result = message;
    }
    public string SendCommand(string Command)
    {
        Task.Factory.StartNew(() =>
        server.Send(Command)
        );
        //wait untill RecieveMessage event raised
        //process Data is recieved
        Task.Factory.StartNew(() =>
        server.Send(AnotherCommand));
        //wait untill RecieveMessage event raised
        //process Data is recieved
        ....
            //till i get what i want
        return Result;
    }
