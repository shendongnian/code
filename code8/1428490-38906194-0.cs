    byte[] yourDocData = null; // in your case (byte[])sqlRead["DocFileText"]
    
    // Save your data as file so word can read it
    var tmpFile = Path.GetTempFileName();
    using (var fileStream = new FileStream(tmpFile, FileMode.Append, FileAccess.Write))
    using (var writer = new BinaryWriter(fileStream)) {
        writer.Write(yourDocData);
    }
    
    // Convert .doc to .rtf
    var newWordFile = (object) tmpFile;
    var newRtfFile = (object) Path.GetTempFileName();
    
    var wordObject = new Microsoft.Office.Interop.Word.Application();
    var docs = wordObject.Documents.Open(ref newWordFile);
    
    docs.SaveAs(ref newRtfFile, WdSaveFormat.wdFormatRTF);
    // This is your rtf code
    var yourRtfCode = File.ReadAllText(newRtfFile.ToString());
    // Dispose
    docs.Close();
    wordObject.Quit();
