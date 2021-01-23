    Redemption.RDOSession session = new Redemption.RDOSession();
    session.MAPIOBJECT = Application.Session.MAPIOBJECT;
    Redemption.RDOAddressEntry addressEntry = session.AddressBook.GAL.ResolveName("User Name From the GAL");
    try
    {
    Redemption.RDOMailTips mailtips = addressEntry.GetMailTips();
    MessageBox.Show(mailtips.DeliveryRestricted.ToString());
    MessageBox.Show(mailtips.CustomMailTip.ToString()); 
    }
    catch (NullReferenceException ex)
    {
    MessageBox.Show(ex.ToString());
    }
