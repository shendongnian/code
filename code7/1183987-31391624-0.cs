    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using System.IO.Ports;
    using System.Threading;
    
    namespace SimpleSerial
    {
        public partial class Form1 : Form
        {
            string RxString;
            public Form1()
            {
                InitializeComponent();
            }
            private void buttonStart_Click(object sender, EventArgs e)
            {
                serialPort1.PortName = "COM3";
                serialPort1.BaudRate = 9600;
                serialPort1.Parity = Parity.None;
                serialPort1.DataBits = 8;
                serialPort1.StopBits = StopBits.One;
                serialPort1.Handshake = Handshake.None;
                serialPort1.RtsEnable = true;
                serialPort1.DtrEnable = true;
                serialPort1.ReadTimeout = 2000; 
                serialPort1.WriteTimeout = 2000;
                serialPort1.Open();
                if (serialPort1.IsOpen)
                {
                    buttonStart.Enabled = false;
                    buttonStop.Enabled = true;
                    textBox1.ReadOnly = false;
                }
            }
            const char STX = '\u0002';
            const char ETX = '\u0003';
            readonly string pull_shelf_104 = string.Format("{0}01P00204##{1}" , STX, ETX);
            private byte[] WrapString(string pull_shelf_104)
            {
                return System.Text.Encoding.ASCII.GetBytes(pull_shelf_104);
            }
            private void linkLabel_HC1_100_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
            {
                if (serialPort1.IsOpen)
                {
                    byte[] data = WrapString(pull_shelf_104);
                    serialPort1.Write(data, 0, data.Length);
                }
            }
            private void buttonStop_Click(object sender, EventArgs e)
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                    buttonStart.Enabled = true;
                    buttonStop.Enabled = false;
                    textBox1.ReadOnly = true;
                }
            }
            private void Form1_FormClosing(object sender, FormClosingEventArgs e)
            {
                if (serialPort1.IsOpen) serialPort1.Close();
            }
            private void DisplayText(object sender, EventArgs e)
            {
                textBox1.AppendText(RxString);
            }
            private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
            {
                RxString = serialPort1.ReadExisting();
                this.Invoke(new EventHandler(DisplayText));
            }
        }
    }
