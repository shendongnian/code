     using Ionic.Zip;
        void  WriteFile()
        {
            string s = Windows.Storage.ApplicationData.Current.TemporaryFolder.Path;
            System.Diagnostics.Debug.WriteLine(s);
            using (ZipFile zip = new ZipFile())
            {
                zip.Password = "123456!";
                zip.Encryption = EncryptionAlgorithm.PkzipWeak;
                zip.AddFile(s + "\\SaveXML.xml", "");
                zip.AddFile(s + "\\Advanced_Windows_Store_App_Development_Using_C#_Exam_Ref_70-485.pdf", "");
             
                 zip.Save(s + "\\MyZipFile123.zip");
            }
        }
