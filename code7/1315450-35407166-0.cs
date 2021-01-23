    private string GetSMTPAddressByFolderItem(Outlook.MAPIFolder mapiFolder)
        {
            string PR_MAILBOX_OWNER_ENTRYID = @"http://schemas.microsoft.com/mapi/proptag/0x661B0102";
            string PR_SMTP_ADDRESS = @"http://schemas.microsoft.com/mapi/proptag/0x39FE001E";
            
            Outlook.Store store = null;
            Outlook.NameSpace ns = null;
            Outlook.AddressEntry sender = null;
            Outlook._ExchangeUser exchUser = null;
            try
            {
                if (mapiFolder == null)
                {
                    return null;
                }
                // Get the parent store.
                store = mapiFolder.Store;
                string storeOwnerEntryId = store.PropertyAccessor.BinaryToString(store.PropertyAccessor.GetProperty(PR_MAILBOX_OWNER_ENTRYID)) as string;
                ns = Application.GetNamespace(Constants.OL_NAMESPACE); // i.e. "MAPI"
                sender = ns.GetAddressEntryFromID(storeOwnerEntryId);
                if (sender != null)
                {
                    if (sender.AddressEntryUserType == Outlook.OlAddressEntryUserType.olExchangeUserAddressEntry ||
                        sender.AddressEntryUserType == Outlook.OlAddressEntryUserType.olExchangeRemoteUserAddressEntry)
                    {
                        exchUser = sender.GetExchangeUser();
                        
                        if (exchUser != null)
                        {
                            return exchUser.PrimarySmtpAddress;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        return sender.PropertyAccessor.GetProperty(PR_SMTP_ADDRESS) as string;
                    }
                }
                return null;
            }
            finally
            {
                if (ns != null)
                {
                    Marshal.ReleaseComObject(ns);
                    ns = null;
                }
                if (store != null)
                {
                    Marshal.ReleaseComObject(store);
                    store = null;
                }
                if (sender != null)
                {
                    Marshal.ReleaseComObject(sender);
                    sender = null;
                }
                if (exchUser != null)
                {
                    Marshal.ReleaseComObject(exchUser);
                    exchUser = null;
                }
            }
        }
