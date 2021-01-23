    // outp is an array with a *single* element
    string[] outp = new string[]
    {
        "CS_" + FileNameFromPath[i]
    };
    DataTable SourceData = GetDataTabletFromCSVFile(FileDirectory[i]);
    // SavePath is an array with a *single* element
    string[] SavePath = new string[]
    {
        DirOutputOlis + @"\" + outp[i]
    };
    CreateCSVFileFromDataTable(SourceData, SavePath[i]);
    Console.WriteLine("File Processed in Output Directory: {0}", outp[i]);
    i++;
