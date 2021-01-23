    public partial class ChildWindow : Window
    {
        public event Action<MyCommunicationObject> MyChildWindowEvent;
        public ChildWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var myObject = new MyCommunicationObject();
            myObject.Message = "Hello from Child Window";
            this.MyChildWindowEvent(myObject);
        }
    }
