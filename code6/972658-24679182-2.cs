    public MainPage()
            {
                InitializeComponent();    
            }
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                LoginWindow loginWnd=new LoginWindow();
                loginWnd.Closed+= new EventHandler(loginWnd_Closed);
                loginWnd.Show();          
            }
            void loginWnd_Closed(object sender, EventArgs e)
            {
                LoginWindow lw = (LoginWindow)sender;
                if (lw.DialogResult == true && lw.nameBox.Text != string.Empty)
                {
                    this.textBlock1.Text = "Hello " + lw.nameBox.Text;
                }
                else if (lw.DialogResult == false)
                {
                    this.textBlock1.Text = "Login canceled.";
                }
            }
