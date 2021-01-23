    using System.Runtime.Remoting.Lifetime;
    //.....
    SaveFileDialog sfd = new SaveFileDialog();
    private ILease sfdLease= null;
    private void toolStripButton1_Click(object sender, EventArgs e)
    {
        if(sfdLease== null)
            sfdLease= (ILease)sfd.InitializeLifetimeService();
        if(sfdLease.CurrentState != LeaseState.Active)
            sfd.ShowDialog(this);
    }
