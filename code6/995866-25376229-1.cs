    public void Find()
    {
        var msg = new FlowDocumentFindMessage("Page");
        Messenger.Default.Send<FlowDocumentFindMessage>( msg );
    }
