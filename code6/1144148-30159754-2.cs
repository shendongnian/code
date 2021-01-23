    private void SetUpDataDirectory()
    {
          string path = Path.Combine(this._appDomainAppPath, "App_Data");
          AppDomain.CurrentDomain.SetData("DataDirectory", (object) path, (IPermission) new FileIOPermission(FileIOPermissionAccess.PathDiscovery, path));
    }
