    public override void UpdateLog(string emailId)
    {
        using (Stream s = File.OpenWrite(logFile))
        {
            using (StreamWriter writer = new StreamWriter(s))
            {
                writer.Write(emailId);
            }
        }
    }
