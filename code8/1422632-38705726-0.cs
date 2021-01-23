    WizardHost host = new WizardHost();
    using (host)
    {
        host.Text = Migration.Properties.Resources.AppName;
        host.ShowFirstButton = false;
        host.ShowLastButton = false;
        host.WizardCompleted += new WizardHost.WizardCompletedEventHandler(this.Host_WizardCompleted);
        //  ************************
        //  CREATE AN INSTANCE HERE
        //  ************************
        DBManip dbController = new DBManip();
        host.WizardPages.Add(1, new Page1());
        host.WizardPages.Add(2, new Page2(dbController));
        host.WizardPages.Add(3, new Page3(dbController));
        host.WizardPages.Add(4, new Page4(dbController));
        host.LoadWizard();
        host.ShowDialog();
    }
