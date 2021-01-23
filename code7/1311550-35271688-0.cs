    string sSavePath = "EmailAttachment/" + intSomeid + "/";
    string strErrorMsg = string.Empty;
    if ((attachments != null))
    {
       CloudFileSystem.SaveFileToCloudSystem(
         attachments[intI].ContentStream, 
         ref strErrorMsg, 
         sSavePath, 
         ConfigHelper.PrivateContainer, 
         attachments[intI].Name);
    }
