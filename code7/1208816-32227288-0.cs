    public static void UploadDocument(string siteURL, string documentListName, string documentListURL,string documentName, byte[] documentStream = null)
        {  
         try
            {
            using (SP.ClientContext clientContext = new SP.ClientContext(siteURL))
            {
                 
				#region"Only if you have credentials"
				NetworkCredential Cred = new NetworkCredential("username", "password");
                clientContext.Credentials = Cred;
				#endregion
               
                SP.List documentsList = clientContext.Web.Lists.GetByTitle(documentListName);
                var fileCreationInformation = new SP.FileCreationInformation();
                //Assign to content byte[] i.e. documentStream
                fileCreationInformation.Content = documentStream;
                //Allow owerwrite of document
                fileCreationInformation.Overwrite = true;
                //Upload URL
                fileCreationInformation.Url = documentName;
                Microsoft.SharePoint.Client.File uploadFile = documentsList.RootFolder.Files.Add(
                    fileCreationInformation);
               
                uploadFile.ListItemAllFields.Update();
                clientContext.ExecuteQuery();
            }
        }
        catch (Exception ex)
        {
        }
    }
