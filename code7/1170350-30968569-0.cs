    internal static void CollectGarbage(int SizeToAllocateInMo)
    {
           long [,] TheArray ;
           try { TheArray =new long[SizeToAllocateInMo,125000]; }low function 
           catch { TheArray=null ; GC.Collect() ; GC.WaitForPendingFinalizers() ; GC.Collect() ; }
           TheArray=null ;
         }
