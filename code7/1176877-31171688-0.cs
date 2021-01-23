    protected void SetTextToCurrentDate(object sender, EventArgs e)
    {
        TextBox myText = sender as TextBox;
        myText.Text = System.DateTime.Now.ToString();
    }
