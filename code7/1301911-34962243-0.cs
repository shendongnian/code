      try
       {
          var assembly = Assembly.GetExecutingAssembly();
      
          var textStreamReader = new StreamReader(_assembly.GetManifestResourceStream("MyNamespace.MyTextFile.txt"));
       }
       catch
       {
    
       }
	
