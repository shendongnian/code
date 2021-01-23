    public partial class ChatWindow : Window
    {
        private Client client;
        public ChatWindow(Client _client)
        {
            InitializeComponent();
            client = _client;
            this.Title = client.Name + " chat";
            client.MessageReceived += OnMessageReceived;
           
            this.Loaded += OnLoaded;
        }
        public void OnMessageReceived(object sender, MessageReceivedArgs e)
        {
            chatControl.Text += e.Sender.Name+": "+ e.Message;
        }
        private void OnLoaded(object sender, EventArgs e)
        {
            client.Send("client " + client.Name + " is loaded!");
        }
      
    }
    public class Client{
        public string Name { get; set; }
        public Chat chat{get;set;}
    
        public Client(string name)
        {
            Name = name;
        }
        public delegate void MessageReceivedEventHandler(object sender, MessageReceivedArgs e);
        public event MessageReceivedEventHandler MessageReceived;
        private void RaiseMessageReceivedEvent(Client sender, string message)
        {
            MessageReceivedArgs e = new MessageReceivedArgs(sender,message);
            if (MessageReceived != null)
                MessageReceived(this, e);
        }
        public void MessageReceivedFromChat(Client sender,string message)
        {
            RaiseMessageReceivedEvent(sender,message);
        }
        public void Send(string message)
        {
            chat.SendMessage(this, message);
        }
      
        
    }
    public class MessageReceivedArgs : EventArgs
    {
        public string Message { get; set; }
        public Client Sender { get; set; }
        public MessageReceivedArgs(Client sender,string message)
        {
            Message = message;
            Sender = sender;
        }
    }
    public class Chat
    {
        private List<Client> clients;
        public Chat()
        {
            clients = new List<Client>();
        }
        public void AddClient(Client client)
        {
            client.chat = this;
            clients.Add(client);
        }
        public void RemoveClient(Client client)
        {
            client.chat = null;
            clients.Remove(client);
        }
        public void SendMessage(Client sender, string message)
        {
            foreach(Client client in clients){
                if (client != sender)
                {
                    client.MessageReceivedFromChat(sender, message);
                }
                
            }
        }
        
    }
