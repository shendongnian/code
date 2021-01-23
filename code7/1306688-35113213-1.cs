    void bClick(object sender, EventArgs e)
    {
        Button cb = (sender as Button);
        MessageBox.Show("You clicked on a Button :D!");
        MessageBox.Show(String.Format("Location of clicked Button : {0}, {1}.", cb.Location.X, cb.Location.Y)); // This is just for example.
    }
