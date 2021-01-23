    namespace TestModal
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                Thread thrd = new Thread(newwindow);
                thrd.IsBackground = true;
                thrd.Start();
            }
    
            private void newwindow()
            {
                Form2 frm2 = new Form2();
                frm2.TopMost = true;
                frm2.ShowDialog();
            }
        }
    }
