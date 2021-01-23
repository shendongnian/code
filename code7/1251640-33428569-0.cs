    namespace FanHubController
    {
    public partial class Form2 : Form
    {
        Form1 mainForm = new Form1();
        
        public Form2(String currFan)
        {
            InitializeComponent();
            currFanBox.Text = currFan;
            
        }
        public void saveToFile(String path, String fileName, String data)
        {
            String appLoc = AppDomain.CurrentDomain.BaseDirectory;
            String fullPath = appLoc + "\\" + path + "\\" + fileName + ".txt";
            string createText = data;
            File.WriteAllText(fullPath, createText);
        }
        public String readFile(String path, String fileName)
        {
            String appLoc = AppDomain.CurrentDomain.BaseDirectory;
            String fullPath = appLoc + "\\" + path + "\\" + fileName + ".txt";
            if (File.Exists(fullPath))
            {
                return System.IO.File.ReadAllText(fullPath);
            }
            else
            {
                return null;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (readFile("bin", "fanSpeeds") != null)
            {
                String[] allData = readFile("bin", "fanSpeed").Split(new[] { ";" }, StringSplitOptions.None);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var form2 = new Form2("");
            form2.Close();
        }
    }
    }
