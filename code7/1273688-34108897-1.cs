    private static void WriteAndOrAppendText(string path, string strText)
    {
    	using (StreamWriter fileStream = new StreamWriter(path, true))
    	{
    		fileStream.WriteLine(strText);
    		fileStream.Flush();
    		fileStream.Close();
    	}
    }
    // Set a variable to the My Documents path.
    string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    
    // Write the text to a new file named "WriteFile.txt".
    WriteAndOrAppendText(mydocpath + @"\WriteFile.txt", text);
    string[] lines = { "New line 1", "New line 2" };
    WriteAndOrAppendText(mydocpath , string.Join(",", lines.ToArray()));
