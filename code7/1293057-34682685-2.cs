    private void Button_Click(object sender, EventArgs e)
    {
        var button = sender as Button;
        //You can manipulate button here
        //Also to extract the button index in array:
        var indexes = (Point)button.Tag;
    
        MessageBox.Show(string.Format("This is the button at {0}, {1}", indexes.X, indexes.Y));
    }
