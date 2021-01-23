    string connection = "LDAP...";
                using (DirectoryEntry DE = new DirectoryEntry(connection))
                {
                    DirectorySearcher dssearch = new DirectorySearcher(connection);
                    {
                        var sgID = ((Label)gr.FindControl("lbID")).Text;
                        dssearch.Filter = String.Format("(&(objectCategory=user)(samaccountname={0}))", ID);
                        SearchResult sresult = dssearch.FindOne();
                        if (sresult != null)
                        {
                            DirectoryEntry de = sresult.GetDirectoryEntry();
                            ((Label)gr.FindControl("lbName")).Text = de.Name;
                        }
                    }
                }
