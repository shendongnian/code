     private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Program.MyCall(this);
        }
    public static void MyCall(Form form)
        {
            form.Logger.Items.Add("Obtaining info ....");
        }
