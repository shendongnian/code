    public override void UpdateLog(string emailId)
    {
        using (StreamWriter writer = File.AppendText(path))
        {
            writer.writeLine(emailId);
        }
    }
