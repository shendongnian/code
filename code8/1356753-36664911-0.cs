    private delegate void SetTextCallback(string text);
    private void SetText(string text)
    {
        if (textBox1.InvokeRequired)
        {	
            SetTextCallback d = new SetTextCallback(SetText);
            Invoke(d, new object[] { text });
        }
        else
        {
            textBox1.Text = text;
        }
    }
    private void ThreadProcSafe()
    {
        SetText("This text was set safely.");
    }
