    public void ConnectTTY()
    {
        ...
        cmd.CaretPosition = cmd.Document.DocumentEnd;
        cmd.ScrollToEnd();
        LastChar = cmd.CaretPosition.DocumentEnd;
    }
    public void ReWriteStream()
    {
        string myText = new TextRange(LastChar, rtb.CaretPosition.DocumentEnd).Text;        
        ...
    }
