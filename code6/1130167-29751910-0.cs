    public void Yes_Click(object sender, RoutedEventArgs e)
    {
        this.DialogResult = true;//close application
        this.Close();
    }
    private void No_Click(object sender, RoutedEventArgs e)
    {
        this.DialogResult = false;//keep application open
        this.Close();
    }
