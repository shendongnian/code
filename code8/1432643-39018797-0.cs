     SPSecurity.RunWithElevatedPrivileges(delegate(){
                using (SPSite site = new SPSite(""))
                {
                    using (SPWeb web = site.OpenWeb())
                    {
                        SPList Library = web.Lists.TryGetList("Document Lib");
                        Library.RootFolder.Files.Add("Nameoffile",bytearray);
                    }
                }
            });
