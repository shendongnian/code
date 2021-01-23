    public void Disable(string userDn)
    {
        try
        {
            DirectoryEntry user = new DirectoryEntry(userDn);
            int val = (int)user.Properties["userAccountControl"].Value;
            user.Properties["userAccountControl"].Value = val | 0x2; 
                 //ADS_UF_ACCOUNTDISABLE;
    
            user.CommitChanges();
            user.Close();
        }
        catch (System.DirectoryServices.DirectoryServicesCOMException E)
        {
            //DoSomethingWith --> E.Message.ToString();    
        }
    }
