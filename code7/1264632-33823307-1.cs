    try
    {
    	File.Move(sourceFile, destinationFile);
    	processedFiles.Add(fileNameNoPath);
    }
    catch (System.IO.IOException e)
    {
        return;
    }
