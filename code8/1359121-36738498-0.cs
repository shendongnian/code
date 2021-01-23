    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            BackgroundWorker bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerAsync();
        }
        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < ListView_addresses.Items.Count; i++)
            {
                try
                {
                    //ListView_addresses.Items[i].Selected = true;
                    ///////////////////////////////
                    //the code for smtp properties
                    //////////////////////////////
                    SmtpServer.Send(mail);
                    //ListView_addresses.Items[i].Checked = true;
                    ((BackgroundWorker)sender).ReportProgress(0, new SmtpResult { Index = i, Checked = true, Selected = true });
                }
                catch
                {
                    ListView_addresses.Items[i].Checked = false;
                    ((BackgroundWorker)sender).ReportProgress(0, new SmtpResult { Index = i, Checked = false, Selected = true });
                }
            }
        }
        void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var result = (SmtpResult)e.UserState;
            ListView_addresses.Items[result.Index].Checked = result.Checked;
            ListView_addresses.Items[result.Index].Selected = result.Selected;
        }
    }
    public class SmtpResult
    {
        public int Index { get; set; }
        public bool Checked { get; set; }
        public bool Selected { get; set; }
    }
