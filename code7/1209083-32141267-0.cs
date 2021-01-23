    public partial class Form1 : Form //Your initial form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            LaunchWorkForm();
        }
        private void LaunchWorkForm()
        {
            var form2 = new Form2();
            form2.OnStatusUpdated += form2_OnStatusUpdated;
            form2.ShowDialog();
        }
        private void form2_OnStatusUpdated(string status)
        {
            //message comes from Working Form
            //Invoke UI thread and update UI here
        }
    }
