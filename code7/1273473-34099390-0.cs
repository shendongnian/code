    public void ProcessFile(string a_strFilePath, IProgress<string> reporter)
    {
     try
     {
          var fileType = this.GetFileType(a_strFilePath);
          string assemblyToLoad = string.Format("DirectoryMonitoring.{0}Loader", fileType);
          Assembly assembly = Assembly.LoadFrom(assemblyToLoad + ".dll");
          if (assembly != null)
          {
            Type type = assembly.GetType(assemblyToLoad);
            dynamic instance = Activator.CreateInstance(type);
            FileSchema fileSchema = instance.Read(a_strFilePath);
            
           //ConcurrentQueue....how can it be used??
           reporter.Report("Reporting data back to UI Thread")
          }
    }
    catch (Exception ex)
    {
            //Log.Write(ex.Message);
    }
    }
