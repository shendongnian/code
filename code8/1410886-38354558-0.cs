       wi.Arguments.OutputArguments.Add(new Argument(
        {
        Name = "Results", // Must match the output parameter in activity
        StorageProvider = StorageProvider.Generic, // Generic HTTP upload (vs A360)
        HttpVerb = HttpVerbType.POST, // Use HTTP POST when delivering result
         Resource = null, // Use storage provided by Design Automation   
        ResourceKind = ResourceKind.ZipPackage // Upload as zip to output directory  
          });
