    x[i].OnClickClient += new EventHandler(Button_Click);
    protected void Button_Click(object sender, EventArgs e)
    {
        Button button = (Button)sender;  // Which button was clicked;
        // Now you can do stuff with the button that was clicked
    }
