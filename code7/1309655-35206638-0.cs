    Redemption.RDOSession session = new Redemption.RDOSession();
    Redemption.RDOMail msg = session.GetMessageFromMsgFile(@"c:\temp\TestContact.msg");
    //is it really a contact? Could be a regular message or an RDODistListItem (all derived from RDOMail)
    Redemption.RDOContact contact = msg as Redemption.RDOContact; 
    if (contact != null)
    {
      MessageBox.Show(contact.FirstName);
    }
