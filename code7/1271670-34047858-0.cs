        public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        ChatMsgDispacher _chatMsgDispacher = new ChatMsgDispacher();
        public ChatChild GetNewChat()
        {
            var child = new ChatChild(); //or where you create the child
            child.SetMsgDispacher(_chatMsgDispacher);
            return child;
        }
    }
    public class ChatMsgDispacher
    {
        public delegate void ChatMsgDelegate(string msg);
        public event ChatMsgDelegate MessageUpdate;
        public void Update(string msg)
        {
            if (MessageUpdate != null)
            {
                MessageUpdate(msg);
            }
        }
    }
    public class ChatChild
    {
        private ChatMsgDispacher _msgDispacher;
        
        public void SetMsgDispacher(ChatMsgDispacher msgDispacher)
        {
            _msgDispacher = msgDispacher;
            _msgDispacher.MessageUpdate += MsgDispacher_MessageUpdate;
        }
        void MsgDispacher_MessageUpdate(string msg)
        {
            //add the msg in the child view
        }
        private void button_enviar_Click(object sender, RoutedEventArgs e)
        {
            string chatMessage = textBox_chat.Text;
            _msgDispacher.Update(chatMessage);
        }
    }
