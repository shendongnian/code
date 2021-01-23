        public partial class LoginUC : UserControl
            {
                public bool ShowLoginUI
                {
                    get { return (bool)GetValue(ShowLoginUIProperty); }
                    set { SetValue(ShowLoginUIProperty, value); }
                }
                
                public static readonly DependencyProperty ShowLoginUIProperty =
                    DependencyProperty.Register("ShowLoginUI", typeof(bool), typeof(UserControl1), new PropertyMetadata(true)); 
    
                ...
    
                private void SignIn_Click(object sender, RoutedEventArgs e)
                {
                   // check login credentials
                   // if success
                   ShowLoginUI = false;
                }
           }
        
