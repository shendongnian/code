    public enum InstallState
    {
        Enabled = 1,
        Disabled = 2,
        Absent = 3,
        Unknown = 4
    }
…
    foreach (ManagementObject m in queryCollection)
    { 
      var status = (InstallState)Enum.Parse(typeof(InstallState), m["InstallState"].ToString());
      Console.WriteLine("Caption : {0}" 
                + Environment.NewLine + "Status : {1}", m["Caption"], status);
    }
