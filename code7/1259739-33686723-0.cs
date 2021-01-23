    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO.Ports;
    using System.Windows.Forms;
    
    namespace serialexample    
    {
        public partial class Form1 : Form
        {
        // variables area
        private string rxstring;
        public Form1()
        {
            InitializeComponent();
        }
        private void btn_send_Click(object sender, EventArgs e)
        {
            if (!serial1.IsOpen)
            {
                serial1.Open();
                rtb_receive.Text = "Port Opened";
                serial1.Write(txt_send.Text);
            }
            else
            {
                serial1.Write(txt_send.Text);
            }
        }
        private void serial1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            rxstring = serial1.ReadExisting();
            this.Invoke(new EventHandler(displayText));
        }
        private void displayText(object o, EventArgs e)
        {
            rtb_receive.AppendText(rxstring);
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            serial1.Close();
        }
    }
 
