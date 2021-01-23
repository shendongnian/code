    public void displayMessage(string data)
    {
        if (InvokeRequired)
        {
            this.Invoke(new Action<string>(displayMessage), new object[] { data });
            return;
        }
        **textBox1.Text = textBox1.Text + data;**
    }
