    ServiceReference.Service1Client Server;
    WaitForm waitF;
    public static void UpdateSNXRATES(object sender, EventArgs e)
    {
        BackgroundWorker bw = new BackgroundWorker();
        bw.WorkerReportsProgress = true;
        bw.DoWork += bw_DoWork;
        bw.RunWorkerCompleted += bw_RunWorkerCompleted;
 
        waitF = new WaitForm();
        waitF.ShowDialog();
    }
    static void bw_DoWork(object sender, DoWorkEventArgs e)
    {
        Server = new ServiceReference.Service1Client();
        Server.ClientCredentials.Windows.ClientCredential.Domain = strDomain;
        Server.ClientCredentials.Windows.ClientCredential.UserName = strUser;
        Server.ClientCredentials.Windows.ClientCredential.Password = strPassword;
        success = Server.UpdateSNXRATES();
    }
    static void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        waitF.Close()
    }
