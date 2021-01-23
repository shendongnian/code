    int docCount = -1;
    int i = 0;
    
    List<Document> Documents = new List<Document>();
    
    foreach (string file in filesCollected)
    {
        string[] sourceFiles = new string[1];
        string bc;
        string bcValue;
        if (Settings.Default.barcodeEngine == "Leadtools")
        {
            bc = BarcodeReader.ReadBarcodeSymbology(file);
            bcValue = "PatchCode";
        }
        else
        {
            bc = BarcodeReader.ReadBacrodes(file);
            bcValue = "009";
        }
        if (bc == bcValue)
        {
            if(Documents.Count > 0)
            {
                Array.Clear(sourceFiles, 0, sourceFiles.Length);
                Array.Resize<string>(ref sourceFiles, 1);
                i = 0;
            }
            sourceFiles[i] =  file ;
            i++;
            Array.Resize<string>(ref sourceFiles, i + 1);
            
            Documents.Add(new Document(sourceFiles, true,""));
            docCount++;
        }
        else
        {
            if (Documents.Count > 0)
            {
                sourceFiles[i] = file;
                i++;
                Array.Resize<string>(ref sourceFiles, i + 1);
                
                Documents[docCount].fullFilePath = sourceFiles;
            }
        }                
    }
