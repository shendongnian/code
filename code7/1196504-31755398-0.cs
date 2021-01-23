    private void setText(string text)
    {
        if (textBox1.InvokeRequired)
        {
            Action callSetText = () => setText(text);
            textBox1.Invoke(callSetText);
        }
        else
        {
            textBox1.Text = text;
        }
    }
