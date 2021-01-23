     public partial class Form1 : Form
        {
            // You will need these delegate to display your data from the other thread
            delegate void del(string data);    
            del MyDelegate;
    
            SerialPort port;
    
            public Form1()
            {
                InitializeComponent();
                // here you create your delegate that will display your data in the textboxes
                MyDelegate = new del(realvalues);
            }
    
               
            private void Form1_Load(object sender, EventArgs e)
            {
                try
                {   // open your port once
                    port = new SerialPort();
                    port.PortName = "COM9";             
                    port.BaudRate = 9600;
                    port.Parity = Parity.None;
                    port.DataBits = 8;
                    port.Open();
                    port.DataReceived += port_DataReceived;    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }    
              
            }
            
            private void realvalues()
            {
                tb1.Text = input.Substring(4, 7);
                tb2.Text = input.Substring(14, 7);
                tb3.Text = input.Substring(24, 7);
                tb4.Text = input.Substring(34, 7);
                tb5.Text = input.Substring(44, 7);
                tb6.Text = input.Substring(54, 7);
                tb7.Text = input.Substring(64, 7);
                tb8.Text = input.Substring(75, 7);
                tb9.Text = input.Substring(86, 7);
                tb10.Text = input.Substring(97, 7);
                tb11.Text = input.Substring(108, 7);
                tb12.Text = input.Substring(123, 7);
            }
    
            private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
            {   // read the data that has arrived
                String s = port.ReadLine();
                // call here your Skeleton method and pass the entire data string
                string input = Skeleton(s);
                // now give the input string to the display method
                this.BeginInvoke(MyDelegate, s);
            }
        private string Skeleton(string portOutput)
        {
             string input = "";
             // parse here through your received string with your algorithm
             // and return the constructed input string
             return input;
        }
    }
    
