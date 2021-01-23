    private void Button_Click(object sender, RoutedEventArgs e)
    {
        string tmpWordFullname = System.IO.Path.GetTempFileName();
        string fileContents = "test test test";
        File.WriteAllText(tmpWordFullname, fileContents);
        Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
        wordApp.DisplayAlerts = WdAlertLevel.wdAlertsNone;
        var currentDoc = wordApp.Documents.Open(tmpWordFullname);
        currentDoc.Activate();
    
        string newTempName = System.IO.Path.GetDirectoryName(tmpWordFullname) + "\\" + System.IO.Path.GetFileNameWithoutExtension(tmpWordFullname) + "1.xml";
    
        currentDoc.SaveAs(newTempName, WdSaveFormat.wdFormatXML);
    }
