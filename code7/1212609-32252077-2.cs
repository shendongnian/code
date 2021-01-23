    static void Enable(string interfaceName)
    {
     System.Diagnostics.ProcessStartInfo psi =
            new System.Diagnostics.ProcessStartInfo("netsh", String.Format("interface set interface {0} enable", interfaceName ));
        System.Diagnostics.Process p = new System.Diagnostics.Process();
        p.StartInfo = psi;
        p.Start();
    }
