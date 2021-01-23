    string FileName = ((System.IO.FileStream (attachments[intI].ContentStream)).Name;
    MemoryStream ms = new MemoryStream();
    using (FileStream file = new FileStream(FileName, FileMode.Open, FileAccess.Read))
    {
    byte[] bytes = new byte[file.Length];
    file.Read(bytes, 0, (int)file.Length);
    ms.Write(bytes, 0, (int)file.Length);
    }
    ms.Position = 0;
    
    CloudFileSystem.SaveFileToCloudSystem(ms, ref strErrorMsg, sSavePath, ConfigHelper.PrivateContainer, attachments[intI].Name);
    ms.Dispose();
