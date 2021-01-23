    public void Button_Click(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        button.IsEnable = false;
        // If you want to access text in the button
        ... = button.Content as object;
    }
