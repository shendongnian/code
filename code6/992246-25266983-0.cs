    private void KillWordByDocumentName(string FullPath)
    {
        object document = null;
        object word = null;
        try
        {
            document = Microsoft.VisualBasic.Interaction.GetObject(FullPath, null);
            word = document.GetType().InvokeMember("Parent", BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.Public, null, document, null);
            word.GetType().InvokeMember("Quit", BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public | BindingFlags.OptionalParamBinding, null, word, new object[] { true });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            // No words are running
        }
        finally
        {
            if (document != null) System.Runtime.InteropServices.Marshal.FinalReleaseComObject(document);
            if (word != null) System.Runtime.InteropServices.Marshal.FinalReleaseComObject(word);
        }
    }
