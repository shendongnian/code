    public partial class Form1 : Form
    {
        SerialPort Port = new SerialPort("COM21", 9600);
    
        public Form1()
        {
            InitializeComponent();
    
            Task.Factory.StartNew(() =>
            {
                if (!Port.IsOpen)
                {
                    Port.Open();
                }
                do
                {
                    if (Port.IsOpen == false)
                    {
                        MessageBox.Show("CLOSED!!!");
                        break;
                    }
                    Port.Write(new byte[] { 0 }, 0, 1);
                }
                while (true);
            });
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            Port.Close();
        }
    }
