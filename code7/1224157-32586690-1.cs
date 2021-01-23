    public void ClickedButton (object sender, EventArgs e)
    {
        // add debug line here 
        string message = (sender as Button).BackColor.ToString();
        Debug.WriteLine(message);
        if ((sender as Button).BackColor == System.Drawing.SystemColors.Control) {
            (sender as Button).BackColor = Color.Turquoise;
        }
    }
