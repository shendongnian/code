    public partial class Form1 : Form
    {
        private byte[] _xbee;
        public Form1()
        {
            if (!File.Exists("serial.txt"))
            {
                File.Create("serial.txt");
            }
            else
            {
                _xbee = File.ReadAllBytes("serial.txt");
            }
            InitializeComponent();
        }
        private void btnSaveSerial_Click(object sender, EventArgs e)
        {
            byte[] xbee { get; set; }
            var xbee_serienr = prop1_serienr.Text;
            xbee = new byte[xbee_serienr.Length / 2];
            for (var i = 0; i < xbee.Length; i++)
            {
                xbee[i] = byte.Parse(xbee_serienr.Substring(i * 2, 2), NumberStyles.HexNumber);
            }
            _xbee = xbee;
            File.WriteAllBytes("serial.txt", xbee);
        }
    }
