    Domino.NotesSession nSession = new Domino.NotesSession();
    nSession.Initialize("secretpassword"); //password for the Notes User
    Domino.NotesDatabase nDatabase = nSession.GetDatabase("SERVER", "names"); //Server and location of the names.nfs file
    Domino.NotesDocument nDocument = nDatabase.CreateDocument();
    NotesStream nStream;
    nDocument.ReplaceItemValue("Subject", tmp.Subject);
    nBody = nDocument.CreateMIMEEntity();                
    nStream = nSession.CreateStream();
    nStream.WriteText(tmp.Body);
    nBody.SetContentFromText(nStream , "text/HTML;charset=UTF-8", MIME_ENCODING.ENC_IDENTITY_7BIT);
    nDocument.EncryptOnSend = true;
    nDocument.Send(false, user.INS_EMAIL);
