    public void Log(string message)
    {
        lock (this.appendBlob)
        {
            appendBlob.AppendText(string.Format("[{0:s}] {1}{2}", DateTime.Now, message, Environment.NewLine));
        }
    }
