    public AboutBox1()
    {
        InitializeComponent();
        this.Text = String.Format("About {0}", AssemblyTitle);
        this.labelProductName.Text = AssemblyProduct;
        this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
        this.labelCopyright.Text = AssemblyCopyright;
        this.labelCompanyName.Text = AssemblyCompany;
        this.textBoxDescription.Text = AssemblyDescription;
        this.Link.Text = "Visit our website!";
        this.Link.Tag = WpfApplication2.Properties.Resources.website;
    }
    private void Link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        System.Diagnostics.Process.Start((sender as LinkLabel).Tag.ToString());
    }
