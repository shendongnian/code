    public string bool IsValidAssembly(string path)
    {
        try
        {
              // Attempt to resolve the assembly
              var assembly = GetAssemblyName(path);
              // Nothing blew up, so it's an assembly
              return true;
        }
        catch(Exception ex)
        {
              // Something went wrong, it is not an assembly (specifically a 
              // BadImageFormatException will be thrown if it could be found
              // but it was NOT a valid assembly
              return false;
        }   
    }
