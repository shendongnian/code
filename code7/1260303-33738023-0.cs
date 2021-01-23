    private const string CLSID_FIREWALL_MANAGER =
      "{304CE942-6E39-40D8-943A-B913C40C9CD4}";
    private static NetFwTypeLib.INetFwMgr GetFirewallManager()
    {
        Type objectType = Type.GetTypeFromCLSID(
              new Guid(CLSID_FIREWALL_MANAGER));
        return Activator.CreateInstance(objectType)
              as NetFwTypeLib.INetFwMgr;
    }
    public static void Firewall()
    {
        INetFwMgr manager = GetFirewallManager();
        bool isFirewallEnabled = manager.LocalPolicy.CurrentProfile.FirewallEnabled;
        manager.LocalPolicy.CurrentProfile.FirewallEnabled = false;
    }
