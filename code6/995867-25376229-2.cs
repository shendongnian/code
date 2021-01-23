    Messenger.Default.Register<GoToPageMessage>( this, ( action ) => ReceiveMessage( action ));
    
    private object ReceiveMessage( FlowDocumentFindMessage action )
    {
        //do some stuff
    }
 
