        try
        {
            DirectoryEntry enTry = new DirectoryEntry("LDAP://OU=Users,OU=Users and Groups,OU=Gentiva,DC=Gentiva,DC=GHSNet,DC=com");
            DirectorySearcher mySearcher = new DirectorySearcher(enTry);
            mySearcher.Filter = "(&(objectClass=user)(extensionAttribute13=" + txtTest.Text.Trim() + "))";
            SearchResult result = mySearcher.FindOne();
            txtBlob.Text = result.Properties["displayname"][0].ToString() +"\n";
            txtBlob.Text += result.Properties["mail"][0].ToString();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
