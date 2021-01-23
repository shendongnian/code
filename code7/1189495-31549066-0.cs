    public void DeleteFileOrDirectory( string path )
    {
      
      try
      {
        File.Delete( path ) ;
      }
      catch ( UnauthorizedAccessException )
      {
        // If we get here,
        // - the caller lacks the required permissions, or
        // - the file has its read-only attribute set, or
        // - the file is a directory.
        //
        // Either way: intentionally swallow the exception and continue.
      }
      
      try
      {
        Directory.Delete( path , true ) ;
      }
      catch ( DirectoryNotFoundException )
      {
        // If we get here,
        // - path does not exist or could not be found
        // - path refers to a file instead of a directory
        // - the path is invalid (e.g., on an unmapped drive or the like)
        //
        // Either way: intentationally swallow the exception and continue
      }
      
      return ;
    }
