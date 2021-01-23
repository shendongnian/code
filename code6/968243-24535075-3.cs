        SPFile file = methods.web.GetFile("MyXMLFile.xml");
        myDoc = new XmlDocument();
        byte[] bites = file.OpenBinary();
        using(MemoryStream strm1 = new MemoryStream()){
             strm1.Write(bites, 0, (int)bites.Length);
             strm1.Position = 0;
             myDoc.Load(strm1);
             
             // all of your edits to the file here
             strm1.Position = 0;
             // save the file back to disk
             using(var fs = new FileStream("FILEPATH",FileMode.Create,FileAccess.ReadWrite)){
                  myDoc.Save(fs);
             }
        }
