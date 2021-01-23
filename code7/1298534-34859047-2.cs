    private void Kommon(object sender, EventArgs e)
    {
        var button = sender as Button;
        //You can use Button.Name or (int)Button.Tag and ...
        MessageBox.Show(button.Name);
    }
