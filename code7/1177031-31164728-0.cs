    /// somewhere else
    enum NextDialog
    {
        Smith,
        Anderson,
        Finished
    }
    
    NextDialog nextDialog = NextDialog.Smith;
    while (nextDialog != NextDialog.Finished)
    {
        NextDialog nextNextDialog;
        switch (nextDialog)
        {
        case NextDialog.Smith:
            // Each handler is responsible for:
            // (1) printing the prompt
            // (2) getting the user response
            // (3) converting the user response into state (program variable) changes, as well as determine the next dialog.
            // Each handler will need access to object fields;
            // these typically do not appear on the arguments list because
            // all instance methods can access all object fields.
            nextNextDialog = ProcessDialogSmith( ... ); 
            break;
        case NextDialog.Anderson:
            nextNextDialog = ProcessDialogAnderson( ... );
            break;
        default:
            throw new UnhandledException();
        }
        nextDialog = nextNextDialog;
    }
