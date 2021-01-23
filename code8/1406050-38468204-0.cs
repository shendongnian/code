     // Read in File
     using (SqlFileStream fileStream = new SqlFileStream(path, transaction, System.IO.FileAccess.Read))
     {
          byte[] buffer = new byte[size];
          int bytesRead = fileStream.Read(buffer, 0, buffer.Length);
    
           // Load Assembly
           Assembly DLL = Assembly.Load(buffer);
    
           Type myInterfaceType = DLL.GetType("MyNamespace.MyClass");
    
           // Get access to the root interface
           IMyInterface myClass = (IMyInterface)Activator.CreateInstance(myInterfaceType);
    
     }
