    // dataholder
    public class ChatMsg
    {
        public string User {get;set;}
        public string Message {get;set;}
    }
    // message store
    private List<ChatMsg> _messages = new List<ChatMsg>();
    // timer
    private Timer _timer;
    // callback for you chatapi?? (like you wrote)
    private void newSource_IncomingMessage(IChatSource sender, string user, string message)
    {
        UpdatedMessageEventHandler temp = UpdatedMessage;
        // lock the store
        lock(_messages)
            _messages.Add(new ChatMsg { User = user, Message = message });
    }
    // constructor
    public Form1()
    {
        // create the check timer.
        _timer = new Timer();
        _timer.Interval = 100;
        _timer.Tick += Timer_Tick;
        _timer.Start();
    }
    // timer method
    private void Timer_Tick(object sender, EventArgs e)
    {
        // copy of the queue
        ChatMsg[] msgs;
        // lock the store and 'move' the messages
        lock(_messages)
        {
            msgs = _messages.ToArray();
            _messages.Clear();
        }
        if(msgs.Length == 0)
            return;
        // add them to the controls
        foreach(var msg in msgs)
        {
            // add the message to the gui controls... (copied from your question)
            int row = allDataGridView.Rows.Add();
            allDataGridView.Rows[row].DefaultCellStyle.ForeColor = source.TextColor;
            allDataGridView.Rows[row].Cells["NameColumn"].Value = user;
            allDataGridView.Rows[row].Cells["MessageColumn"].Value = message;
       }
    }
