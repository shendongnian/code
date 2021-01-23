     private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Program.MyCall(this);
        }
    public static void MyCall(Form form)
        {
            MainWindow ControlForm = new MainWindow();
            this.Logger.Items.Add("Obtaining info ....");
        }
