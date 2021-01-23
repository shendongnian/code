    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            var task = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1000);
                BeginInvoke((Action)delegate { throw new NotImplementedException(); });
            });
            try
            {
                task.Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
