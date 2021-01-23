        private void txtMainEntry_KeyUp(object sender, KeyEventArgs e)
        {
            Variables variable;
            //Passing user input to class member via constructor
            variable = new Variables(txtMainEntry.Text);
            //Get value from class member
            showUserEntry.Text = variable.UserInput;
            if (e.Key == Key.Return & variable.UserInput == "Hello World")
            {
                TargetWindow tWindow = new TargetWindow(variable);
                tWindow.ShowDialog();
                this.Close();
            }
        }
        public partial class TargetWindow : Window
        {
            Variables variable ;
            public TargetWindow(Variables variable)
            {
                InitializeComponent();
                this.variable = variable;
            }
 
            private void lblDisplayVariableValue_Loaded(object sender, RoutedEventArgs e)
            {
                //use variable field
            }
        }
