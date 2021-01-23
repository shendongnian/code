    private void InvokeLabel(string text)
    {
        if (toolStripLabel1.InvokeRequired)
        {
            toolStripLabel1.Invoke(new Action<string>(InvokeLabel), text);
        }
        else
        {
            toolStripLabel1.Text = text;
        }
    }
