        List<string> theList = new List<string>{ "AAA", "BBB" };
        // number of characters
        var allSize = theList.Sum(s => s.Length);
        // available memory
        Process proc = Process.GetCurrentProcess();
        var availableMemory = proc.PrivateMemorySize64;;
        if (availableMemory > allSize) {
           // you can try
           try {
              String allString = String.Join(",", theList.ToArray());
           } catch (OutOfMemoryException e) {
              // ... handle OutOfMemoryException exception (e)
           }
        } else {
           // it is not going to work...
        }
