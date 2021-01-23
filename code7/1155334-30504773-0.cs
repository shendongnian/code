    public partial class Form1 : Form
    {
        private static IEventBroker eventBroker;
        // Other private properties
    
        public Form1(IEventBroker eventBroker)
        {
            InitializeComponent();
            this.eventBroker = eventBroker;
           
            this.eventBroker.Register<NotifyBaloonText>(changeNotifyBalloonText);
        }
        public static void changeNotifyBalloonText(NotifyBaloonText args)
        {
            notifyIcon1.BalloonTipText = args.NewText;
            notifyIcon1.ShowBalloonTip(args.TimeInMillis);
        }
        // Rest of public and private methods
    }
