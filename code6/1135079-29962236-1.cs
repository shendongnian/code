    string package = "";
    var versionAttribute = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyFileVersionAttribute), true).GetValue(0) as AssemblyFileVersionAttribute;
    if (versionAttribute != null)
    {
       package = versionAttribute.Version.Tostring();
    }
