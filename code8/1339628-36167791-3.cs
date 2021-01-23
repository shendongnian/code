    public partial class DialogForm : Window
    {
        public DialogForm()
        {
            InitializeComponent();
        }
        void submitButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
