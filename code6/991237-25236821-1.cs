        private void txtMainEntry_KeyUp(object sender, KeyEventArgs e)
        {
            Variables variable;
            //Passing user input to class member via constructor
            variable = new Variables(txtMainEntry.Text);
            //Get value from class member
            showUserEntry.Text = variable.UserInput;
            if (e.Key == Key.Return & variable.UserInput == "Hello World")
            {
                TargetWindow tWindow = new TargetWindow();
                tWindow.Variable = variable;
                tWindow.ShowDialog();
                this.Close();
            }
        }
        public partial class TargetWindow : Window
        {
            public Variables Variable { get; set; }
            public TargetWindow(Variables variable)
            {
                InitializeComponent();
            }
 
            private void lblDisplayVariableValue_Loaded(object sender, RoutedEventArgs e)
            {
                //use Variable property
            }
        }
