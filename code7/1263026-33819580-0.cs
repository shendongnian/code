            private void adxRibBtnAddEmailAddress_OnClick(object sender, IRibbonControl control, bool pressed)
            {
                Outlook.MailItem mailItem = null;
                Outlook.Recipient recipient = null;
                string recipientsEmail = "";
                string sendersEmail = "";
    
                try
                {               
                    mailItem = OutlookHelper.GetSelectedMailItem();
                    if (mailItem != null)
                    {
                        if (mailItem.SenderEmailType == "EX")
                            sendersEmail = GetSenderEmailAddress(mailItem);
                        else
                            sendersEmail = mailItem.SenderEmailAddress;
    
                        if (!string.IsNullOrEmpty(sendersEmail))
                        {
                            if (sendersEmail == Globals.OLCurrentUserEmail) // Sent mail
                            {
                                recipient = mailItem.Recipients[1];
                                if (recipient != null)
                                {
                                    recipientsEmail = OutlookHelper.GetAddress(ref recipient);
                                    if (!string.IsNullOrEmpty(recipientsEmail))
                                    {
                                        // Do Something
                                    }
                                }
                            }
                            else // inbox mail
                            {
                                // Do Something
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.DebugMessage(2, "AddinModule : Error in adxRibBtnsddemailaddress_OnClick() : " + ex.Message);
                }
                finally
                {
                    if (recipient != null) Marshal.ReleaseComObject(recipient);
                    if (mailItem != null) Marshal.ReleaseComObject(mailItem);
                    Cursor.Current = Cursors.Default;
                }
            }
    
            private string GetSenderEmailAddress(Outlook.MailItem oM)
            {
                Outlook.PropertyAccessor oPA = null;
                Outlook.AddressEntry oSender = null;
                Outlook.ExchangeUser oExUser = null;
    
                string SenderID;
                string senderEmailAddress;
    
                try
                {
                    // Create an instance of PropertyAccessor 
                    oPA = oM.PropertyAccessor;
                    // Obtain PidTagSenderEntryId and convert to string 
                    SenderID = oPA.BinaryToString(oPA.GetProperty("http://schemas.microsoft.com/mapi/proptag/0x0C190102"));
                    // Obtain AddressEntry Object of the sender 
                    oSender = Globals.ObjNS.GetAddressEntryFromID(SenderID);
    
                    oExUser = oSender.GetExchangeUser();
                    senderEmailAddress = oExUser.PrimarySmtpAddress;
    
                    return senderEmailAddress;
                }
                catch (Exception ex)
                {
                    Debug.DebugMessage(2, "AddinModule : Error in adxRibBtnAddGenInteraction_OnClick() : " + ex.Message);
                    return null;
                }
                finally
                {
                    if (oExUser != null) Marshal.ReleaseComObject(oExUser);
                    if (oSender != null) Marshal.ReleaseComObject(oSender);
                    if (oPA != null) Marshal.ReleaseComObject(oPA);                
                }
            }
