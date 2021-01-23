            Redemption.RDOAddressEntry raddressEntry = null;
            try
            {  
                string displayName = (string)accountDisplayNames[domainSelect.Text];
                Microsoft.Office.Interop.Outlook.Application app = new Outlook.Application();
                Redemption.RDOSession session = new Redemption.RDOSession();
                session.MAPIOBJECT = app.Session.MAPIOBJECT;
                //if you already have a pointer to the Outlook.Application object, Or call Logon
                RDOStores stores = session.Stores;
                RDOAccounts accounts = session.Accounts;
              
                
                if (stores.DefaultStore.Name.ToLower().Equals(displayName.ToLower()))
                {
                    WriteLog("Default account:" + stores.DefaultStore.Name.ToLower());
                    // MessageBox.Show("Outlook's Default account name: " + stores.DefaultStore.Name.ToLower() + " matches with selected domain " + displayName);
                    raddressEntry = session.AddressBook.ResolveName(name, true);
                }
                else
                {
                    MessageBox.Show("The selected domain " + displayName + " is not Outlook's Default domain. Set this as default domain to resolve", "Default Mailbox Setting");
                    accounts.DisplayAccountList();
                    WriteLog("Default account:" + stores.DefaultStore.Name.ToLower());
                    raddressEntry = session.AddressBook.ResolveName(name, true);
                }
            }
            catch(System.Exception e)
            {
                MessageBox.Show("Resolving error:" + e.GetBaseException());
                WriteLog("*******inside findAndWriteDirectReporteesintoPDF******");
            }
            
           
            return raddressEntry;
        }
