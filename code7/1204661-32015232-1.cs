    Redemption.RDOSession Session = new Redemption.RDOSession();
    Session.MAPIOBJECT = Application.Session.MAPIOBJECT;
    set rFolder = Session.GetFolderFromID(YourOutlookFolder.EntryID);
    Redemption.RDOMail rMsg = rFolder.Items.Find("Recipients LIKE 'John@foo.com' ") ;
    AlreadyEmailed = rMsg != null;
