    // Save current dir before changing directories
    var currentDir = Directory.GetCurrentDirectory();
    
    // Change to directory where the file is
    Directory.ChangeDirectory(Path.GetDirectoryName(path));
    // Pass in *only* the filename, not the whole path
    // Because we changed to that file's directory the rest of the code should find it without needing the whole path
    using (var pkg = new ExcelPackage(new FileInfo(Path.GetFilename(path))))
    {
         var sheet = pkg.Workbook.Worksheets.Add("Manifest");
         var w = new ExcelWriter<ManifestLine>(sheet);
        
         // ... Write data ...
        
         await w.CloseAsync(Token).ConfigureAwait(false);
         pkg.Save();
    }
        
    Directory.ChangeDirectory(currentDir);  // Change back to whatever directory the program was in before all this.
