    public class MainWindow : Window
    {
        List<ChatWindow> chatWindows = new List<ChatWindow>();
        public void AddChatWindow()
        {
            ChatWindow win = new ChatWindow();
            win.NewMessage += MessageReceived;
            win.Show();
            chatWindows.Add(win);
        }
        void MessageReceived(object sender, MessageEventArgs e)
        {
            ChatWindow me = sender as ChatWindow;
            if (me != null)
            {
                foreach (ChatWindow win in chatWindows)
                {
                    if (win != me)
                    {
                        win.Add(e.Message);
                    }
                }
            }
        }
    }
    
    public class ChatWindow : Window
    {
        public event EventHandler<MessageEventArgs> NewMessage;
    
        public void Add(string message)
        {
            Messsage += message;
        }
        public void UpdateText(string text)
        {
            if (NewMessage != null)
            {
                NewMessage(this, new MessageEventArgs(Message = text));
            }
        }
        public string Message {get;set;}
    }
    public class MessageEventArgs : EventArgs
    {
         public string Message{get;set;}
    }
