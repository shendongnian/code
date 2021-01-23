    public override void Uninstall(System.Collections.IDictionary savedState)
        {
            KillProcess();
            base.Uninstall(savedState);
        }
