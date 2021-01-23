    string[] ext= new string[] { "txt", ".msg", "dat" };
    totalFilesInTN = Directory.EnumerateFiles(dlg1.SelectedPath,
                                              "*.*",
                                              SearchOption.AllDirectories)
                     .Count(s => ext.Any(s1 
                                         => s1.Replace(".", "") == Path.GetExtension(s).Replace(".", "")));
