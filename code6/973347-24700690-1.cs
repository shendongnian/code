     public partial class loginChildWindow : ChildWindow
        {
    
            private readonly MainPage _mainPage;
            public loginChildWindow(MainPage mainPage)
            {
                InitializeComponent();
                _mainPage = mainPage;
            }
    
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                if (txtUsrname.Text == "Username" && txtPassword.Password == "Password")
                {
    
                    _mainPage.Visibility = Visibility.Visible;
                   this.DialogResult = true;            
                }
                else
                {
                    MessageBox.Show("Incorrect username and/orpassword", "Error", MessageBoxButton.OK);
                }
            }
            private void CancelButton_Click(object sender, RoutedEventArgs e)
            {
                this.DialogResult = false;
            }   
    
    
            private void Login_Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
            {
                Visibility = Visibility.Collapsed;
            }
        }
