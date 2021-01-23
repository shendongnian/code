    Filter = ".DOC|.DOCX|.XLS|.XLSX|.PDF|.TXT|.TIF|.TIFF";
    public string[] GetFiles(string SourceFolder, string Filter)
    {
         List<string> alFiles = new List<string>();
         
         string[] MultipleFilters = Filter.Split('|');
         foreach (string FileFilter in MultipleFilters)
         {
             alFiles.AddRange(Directory.GetFiles(SourceFolder, FileFilter));
         }
         // Applies the Distinct() operation to only the file names
         return alFiles.Select(f => f.Split('.')[0]).Distinct().ToArray();
    }
