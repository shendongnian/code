    public partial class Form1 : Form
    {
        BackgroundWorker _backgroundWorker;
        public Form1()
        {
            InitializeComponent();
            var worker = new Worker(SynchronizationContext.Current);
            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.DoWork += (sender, e) => worker.DoWork();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (_backgroundWorker.IsBusy == false)
            {
                _backgroundWorker.RunWorkerAsync();
            }
        }
    }
    public class Worker
    {
        private readonly SynchronizationContext _synchronizationContext;
        private Form2 form2;
        public Worker(SynchronizationContext synchronizationContext)
        {
            _synchronizationContext = synchronizationContext;
            form2 = new Form2();
        }
        public void DoWork()
        {
            _synchronizationContext.Send(callback => OpenForm(), null);
        }
        public void OpenForm()
        {
            form2.ShowDialog();
            if (!form2.blnVerified)
            {
                return;
            }
            else
            {
                //do something
            }
        }
    }
