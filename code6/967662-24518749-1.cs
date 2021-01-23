    using System.Runtime.Remoting.Lifetime;
    //.....
    private SaveFileDialog sfd;
    private ILease sfdLease;
    
    public Form1()
    {
        InitializeComponent();
        sfd = new SaveFileDialog();
        sfdLease= (ILease)sfd.InitializeLifetimeService();
    }
    private void toolStripButton1_Click(object sender, EventArgs e)
    {
        if(sfdLease.CurrentState != LeaseState.Active)
            sfd.ShowDialog(this);
    }
