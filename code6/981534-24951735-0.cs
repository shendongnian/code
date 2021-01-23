    // When the form/parent loads bind the event ONCE here.
    public void FormLoads()
    {
        webBrowser1.DocumentCompleted += webBrowser1_DocumentCompleted;
    }
    // Just navigate here and the event will still be raised
    private void button1_Click(object sender, EventArgs e)
    {
        webBrowser1.Navigate("xxxx");   
    }
