    public partial class Person_UC : UserControl
    {
        public Person_UC()
        {
            InitializeComponent();
        }
        private void Loaded(object sender, RoutedEventArgs e)
        {
            //Use a Message to notify your Student_UC's ViewModel that you would like to disable its ComboBox
           Messenger.Default.Send<ChangeComboBoxEnabilityMessage>(new ChangeComboBoxEnabilityMessage(false));
        } 
    }
