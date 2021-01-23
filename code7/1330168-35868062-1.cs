        public MessagingControl()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty MessageTextSendProperty =
           DependencyProperty.Register("MessageTextSend", typeof(string), typeof(MessagingControl),
               new FrameworkPropertyMetadata(default(string), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public string MessageTextSend
        {
            get { return (string)GetValue(MessageTextSendProperty); }
            set { SetValue(MessageTextSendProperty, value); }
        }
