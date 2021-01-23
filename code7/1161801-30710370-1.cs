    public void ReWriteStream()
    {
        LastChar = rtb.CaretPosition.ContentEnd.GetInsertionPosition(LogicalDirection.Backward);
        string myText = new TextRange(LastChar, rtb.CaretPosition.ContentEnd).Text;        
        ...
    }
