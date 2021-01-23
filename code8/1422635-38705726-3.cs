    WizardHost host = new WizardHost();
    using (host)
    {
        host.Text = Migration.Properties.Resources.AppName;
        host.ShowFirstButton = false;
        host.ShowLastButton = false;
        host.WizardCompleted += new WizardHost.WizardCompletedEventHandler(this.Host_WizardCompleted);
        //  ************************
        //  Create shared "reference" instance
        //  ************************
        Reference<DBManip> dbControllerRef = new Reference<DBManip>();
        host.WizardPages.Add(1, new Page1());
        host.WizardPages.Add(2, new Page2(dbControllerRef));
        host.WizardPages.Add(3, new Page3(dbControllerRef));
        host.WizardPages.Add(4, new Page4(dbControllerRef));
        host.LoadWizard();
        host.ShowDialog();
    }
