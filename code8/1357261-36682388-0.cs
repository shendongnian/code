    if (buffer[12] == 129)
    {
        if (textBox1.InvokeRequired)
        {
            textBox1.Invoke((MethodInvoker)delegate
            {
                textBox1.BackColor = System.Drawing.Color.Green;
            });
        }
    }
    if (buffer[12] == 128)
    {
        if (textBox1.InvokeRequired)
        {
            textBox1.Invoke((MethodInvoker)delegate
            {
                textBox1.BackColor = System.Drawing.Color.Red;
            });
        }
    }
