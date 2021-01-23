    public static void writeOut(string str)
    {
        o.Invoke((MethodInvoker)delegate {
            o.Text = str + Environment.NewLine; // runs on UI thread
        });
    }
