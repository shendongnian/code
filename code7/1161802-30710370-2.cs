    public void ReWriteStream()
    {
        var myText = new TextRange(rtb.CaretPosition.GetLineStartPosition(0), rtb.CaretPosition.GetLineStartPosition(1) ?? rtb.CaretPosition.DocumentEnd).Text;    
        ...
    }
