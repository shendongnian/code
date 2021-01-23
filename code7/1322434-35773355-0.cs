    public static void Convert(string input, string output, Word.WdSaveFormat format)
    {
        // Create an instance of Word.exe>
        var oWord = new Word.Application();
        // open the protected document
        var oDoc = oWord.Documents.Open(input, PasswordDocument: "abc", WritePasswordDocument: "xyz");
        // save the document without password first
        oDoc.SaveAs2(FileName: output, Password: "", WritePassword: "");
        // close and reopen
        oDoc.Close();
        oDoc = oWord.Documents.Open(output);
        // set the password
        oDoc.SaveAs2(FileName: output, FileFormat: format, Password: "abc", WritePassword: "xyz");
        oWord.Quit();
    }
