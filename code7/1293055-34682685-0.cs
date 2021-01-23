    private void Button_Click(object sender, EventArgs e)
    {
        var button = sender as Button;
        var indexes = button.Tag as Point;
    
        MessageBox.Show(string.Format("This is the button at {0}, {1}", indexes.X, indexes.Y));
    }
