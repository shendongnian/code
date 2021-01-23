    private void TextBox_KeyDown(object sender, KeyEventArgs e)
    {
        DateTime dt = DateTime.Now;
        dt.AddMilliseconds(e.Timestamp - Environment.TickCount);
     
        Trace.WriteLine(string.Format("Key DOWN at: {0}", dt.ToString("h:mm:ss.FFF tt")));
    }
