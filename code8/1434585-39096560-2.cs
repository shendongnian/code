    public void SendFile(File fileToSend)
    {
          //process the file
          FileStream objfilestream = new FileStream(fileToSend.FullName, FileMode.Open, FileAccess.Read);
          int len = (int)objfilestream.Length;
          Byte[] documentcontents = new Byte[len];
          objfilestream.Read(documentcontents, 0, len);
          objfilestream.Close();
          FileTransfer newFiletoSend = new FileTransfer(file.Name, documentcontents);
          string raw = new JavaScriptSerializer().Serialize(newFiletoSend); 
          //send it
          nameOfTheWebServiceClass.nameOfTheAsmxFile service = new nameOfTheWebServiceClass.nameOfTheAsmxFile();
          service.GetFile(raw); //GetFile is the name of the funcion you want to use in the .asmx webservice.
     }
