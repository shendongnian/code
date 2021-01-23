    namespace WindowsFormsApplication1
    {
     public partial class Form1 : Form
    {
        string InputData = String.Empty;
        delegate void SetTextCallback(string text);
        
       
        public Form1()
        {
            InitializeComponent();
            string[] ports = SerialPort.GetPortNames();
          
            Console.WriteLine("The following serial ports were found:");
            // Display each port name to the console.
            foreach (string port in ports)
            {
                comboBox1.Items.Add(port);
            }
        ;}
          public void guzikpolacz_Click(object sender, EventArgs e)
        {
            serialPort1.PortName = comboBox1.Text;         // Ustawiamy numer Portu COM
                    // Ustawiamy wartość baudrate portu            
            //Inne ustawienia zdefiniowane na stałe
            serialPort1.Parity = Parity.None;   // bez parzystości
            serialPort1.StopBits = StopBits.One;  // jeden bit stopu
            serialPort1.DataBits = 8;    // osiem bitów danych   
            
            
            serialPort1.Open();
            
            polestatusu.Text = "Port Otwarty";
           
            panel1.BackColor = Color.Lime;
            guzikpolacz.Enabled = false;          //blokujemy przycisk Połącz
            guzikrozlacz.Enabled = true;   
    }
        private void guzikrozlacz_Click(object sender, EventArgs e)
        {
            serialPort1.Close();             //Zamykamy SerialPort
            panel1.BackColor = Color.Red;
            polestatusu.Text = "Port Zamknięty";
            guzikpolacz.Enabled = true;   //aktywujemy przycisk Połącz
            guzikrozlacz.Enabled = false;  // deaktywujemy przycisk Rozłącz
        }
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => serialPort1_DataReceived(sender, e)));
            }
            else
            {
                var sp = sender as SerialPort;
                //this assumes you want the data from the arduino as text.  
                // you may need to decode it here.
                textBox1.Text = sp.ReadExisting();
            }
        }
     private delegate void UpdateUiTextDelegate(string text);
    
    
    
     public Delegate myDelegate { get; set; }
        }
    }
