    102 try 
    103             { 
    104                 return a.GetTypes(); 
    105             } 
    106             catch (ReflectionTypeLoadException ex) 
    107             { 
    108                 _trace.TraceWarning("Some of the classes from assembly \"{0}\" could Not be loaded when searching for Hubs. [{1}]\r\n" + 
    109                                     "Original exception type: {2}\r\n" + 
    110                                     "Original exception message: {3}\r\n", 
    111                                     a.FullName, 
    112                                     a.Location, 
    113                                     ex.GetType().Name, 
    114                                     ex.Message); 
 
     
    116                 return ex.Types.Where(t => t != null); 
    117             } 
