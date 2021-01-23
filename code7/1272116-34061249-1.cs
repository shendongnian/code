    public partial class Form1 : Form
    {
        private enum Message
        {
            ShowForm2,
            SuspendWork,
            ResumeWork,
            FinishWorker1
            // ... and whatever you want
        }
        private Timer timer;
        private ConcurrentQueue<Message> messagesToUI = new ConcurrentQueue<Message>();
        private ConcurrentQueue<Message> messagesToWorker = new ConcurrentQueue<Message>();
        public Form1()
        {
            InitializeComponent();
            timer = new Timer(this);
            timer.Interval = 10;
            timer.Tick += PollUIMessages;
            timer.Enabled = true;
        }
        void PollUIMessages(object sender, EventArgs e)
        {
            // do we have a new message?
            Message message;
            if (messagesToUI.TryDequeue(out message))
            {
                switch (message)
                {
                    case Message.ShowForm2:
                        Form2 f = new Form2();
                        f.Show();
                        // todo: in Form2.Close add a Resume message to the messagesToWorker
                        break;
                    // ... process other messages
                }
            }
        }
        void back_DoWork(object sender, DoWorkEventArgs e)
        {
            // Here you are in the worker thread. You can send a message to the
            // UI thread like this:
            messagesToUI.Enqueue(Message.ShowForm2);
            bool isWorking = true;
            // and here you can poll the messages to the worker thread
            while (true)
            {
                Message message;
                if (!messagesToWorker.TryDequeue(out message))
                {
                    // no message: idle or work
                    if (isWorking)
                        DoSomeWork(); // do whatever you want
                    else
                        Thread.CurrentThread.Sleep(10);
                    continue;
                }
                switch (message)
                {
                    case Message.FinishWorker1:
                        // finishing the worker: jumping out
                        return;
                    case Message.SuspendWork:
                        isWorking = false;
                        break;
                    case Message.ResumeWork:
                        isWorking = true;
                        break;
                }
            }
        }
