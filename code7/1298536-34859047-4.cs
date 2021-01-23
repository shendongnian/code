    private void Kommon(object sender, EventArgs e)
    {
        var button = sender as Button;
        //You can use button.Name or (int)button.Tag and ...
        MessageBox.Show(button.Name);
    }
