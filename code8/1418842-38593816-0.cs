    public partial class ProgressForm : Form
    {
        private int currentValue = 0;
        public ProgressForm()
        {
            InitializeComponent();
        }
        public void ChangeValue(int newValue)
        {
            currentValue = newValue;
            lblValue.Text = string.Format("Current value: {0}", currentValue);
            lblValue.Refresh();   //Call Refresh to make the label update itself
        }
    }
    static class Program
    {
        private static ProgressForm progressForm = null;
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            progressForm = new ProgressForm();
            progressForm.Show();
            doWork();
            progressForm.Close();
        }
        //arbitrary example of processing that takes some period of time
        static void doWork()
        {
            int i = 0;
            while (i < 100000)
            {
                progressForm.ChangeValue(i);
                Thread.Sleep(1);
                i++;
            }
            return;
        }
    }
