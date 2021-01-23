    Redemption.RDOSession session = new Redemption.RDOSession();
    Redemption.RDOMail msg = session.GetMessageFromMsgFile(@"c:\temp\TestContact.msg");
    //is it really a contact? Could be a regular message or an RDODistListItem (all derived from RDOMail)
    Redemption.RDOContactItem contact = msg as Redemption.RDOContactItem; 
    if (contact != null)
    {
      MessageBox.Show(contact.FirstName);
    }
    else 
    {
       Redemption.RDODistListItem dl= msg as Redemption.RDODistListItem; 
       if (dl != null)
       {
          MessageBox.Show(dl.FileAs);
        }
    }
