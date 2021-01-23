            Console.WriteLine("Account ID:" + accountID);
            FoldersApi foldApi = new FoldersApi();
            //create fr object
            FoldersRequest fr = new FoldersRequest();
            //instantiate EnvelopeIds string list, to a new string list..
            fr.EnvelopeIds = new List<string>();
            //get folders
            var folders = foldApi.List(accountID);
            string sentFolderID = "";
            string loadedFolderID = "";
            foreach (var fold in folders.Folders)
            {//get sent/loaded folder IDs
                if (fold.Name == "Sent Items") { sentFolderID = fold.FolderId; }
                else if(fold.Name == "Loaded") { loadedFolderID = fold.FolderId; }
            }
            //list the items in the folder
            var envID = foldApi.ListItems(accountID, sentFolderID);
            //for each item in the folder...
            foreach (FolderItem fi in envID.FolderItems)
            {
                EnvelopesApi envApi = new EnvelopesApi();
                //get a list of documents in the envelope
                EnvelopeDocumentsResult docsList = envApi.ListDocuments(accountID, fi.EnvelopeId);
                //list recipients
                Recipients listRecip = envApi.ListRecipients(accountID, fi.EnvelopeId);
                string listOfInfo = "";
                Envelope myEnv = envApi.GetEnvelope(accountID, fi.EnvelopeId);
                if (myEnv.Status == "completed")
                {
                    foreach (var signer in listRecip.Signers)
                    {
                        var listTabs = envApi.ListTabs(accountID, fi.EnvelopeId, signer.RecipientId);
                        foreach (var tab in listTabs.TextTabs)
                        {
                            //get info out of document
                            listOfInfo += tab.TabLabel + " - " + tab.Value + " \n ";
                            bigString += tab.TabLabel + " - " + tab.Value + " \n ";
                        }
                        Console.WriteLine("Stop here");//breakpoint
                    }
                    //add this envelope ID to the list of envelopes to be moved
                    fr.EnvelopeIds.Add(myEnv.EnvelopeId);                    
                }
            }
            //move all the envelopes in the list
            if (fr.EnvelopeIds.Count >= 1) { foldApi.MoveEnvelopes(accountID, loadedFolderID, fr); }
