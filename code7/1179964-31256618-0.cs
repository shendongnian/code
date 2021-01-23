    int charReadSinceLastMemCheck = 0 ;
    using (var streamReader = File.OpenText(_filePath))
    {
        
        int lineNumber = 1;
        string currentString = String.Empty;
        while ((currentString = streamReader.ReadLine()) != null)
        {
            ProcessString(currentString, lineNumber);
            Console.WriteLine("Line {0}", lineNumber);
            lineNumber++;
            totalRead+=currentString.Length ;
            if (charReadSinceLastMemCheck>1000000) 
            { // Check memory left every Mb read, and collect garbage if required
              CollectGarbage(100) ;
              charReadSinceLastMemCheck=0 ;
            } 
        }
    }
    internal static void CollectGarbage(int SizeToAllocateInMo)
    {
           long [,] TheArray ;
           try { TheArray =new long[SizeToAllocateInMo,125000]; }low function 
           catch { TheArray=null ; GC.Collect() ; GC.WaitForPendingFinalizers() ; GC.Collect() ; }
           TheArray=null ;
    }
