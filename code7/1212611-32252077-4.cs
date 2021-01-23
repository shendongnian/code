        static void SetInterface(string interfaceName, bool enable)
        {
            string type;
            if (enable == true) type = "enable";
            else type = "disable";
            System.Diagnostics.ProcessStartInfo psi =
                new System.Diagnostics.ProcessStartInfo("netsh", String.Format("interface set interface {0} {1}", interfaceName, type));
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo = psi;
            p.Start();
        }
