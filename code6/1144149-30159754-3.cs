    [PermissionSet(SecurityAction.Assert, Unrestricted = true)]
    internal static string GetDataDirectory()
    {
          if (HostingEnvironment.IsHosted)
            return Path.Combine(HttpRuntime.AppDomainAppPath, "App_Data");
          string path1 = AppDomain.CurrentDomain.GetData("DataDirectory") as string;
          if (string.IsNullOrEmpty(path1))
          {
            string path1_1 = (string) null;
            Process currentProcess = Process.GetCurrentProcess();
            ProcessModule processModule = currentProcess != null ? currentProcess.MainModule : (ProcessModule) null;
            string path2 = processModule != null ? processModule.FileName : (string) null;
            if (!string.IsNullOrEmpty(path2))
              path1_1 = Path.GetDirectoryName(path2);
            if (string.IsNullOrEmpty(path1_1))
              path1_1 = Environment.CurrentDirectory;
            path1 = Path.Combine(path1_1, "App_Data");
            AppDomain.CurrentDomain.SetData("DataDirectory", (object) path1, (IPermission) new FileIOPermission(FileIOPermissionAccess.PathDiscovery, path1));
          }
          return path1;
    }
