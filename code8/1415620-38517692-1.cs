    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.IO.Ports;
    using System.Threading;
    
    namespace PruebaComandos
    {
        public partial class Form1 : Form
        {
            SerialPort Puerto = new SerialPort();
            string buffer = String.Empty;
            Thread DemoThread;
            byte[] Existen;
            public Form1(string argumento)
            {
                InitializeComponent();
                Puerto.PortName = "Com4";
                Puerto.BaudRate = 9600;
                this.textoComandoLinea.Text = argumento;
                Puerto.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                CloseSerial();
                OpenSerial();
                Puerto.Write(argumento + "\r\n");
               }
            public Form1()
            {
                InitializeComponent();
                Puerto.PortName = "Com4";
                Puerto.BaudRate = 9600;
                Puerto.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                CloseSerial();
                OpenSerial();
                Puerto.Write("Inicio");
            }
    
            private void botonSend_Click(object sender, EventArgs e)
            {
                string Input = textoComandoLinea.Text;
                OpenSerial();
                Puerto.Write(Input);
            }
    
            void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
            {
                SerialPort sp = (SerialPort)sender;
                switch (e.EventType)
                {
                    case SerialData.Chars:
                        buffer += sp.ReadExisting();
                        this.DemoThread = new Thread(new ThreadStart(ThreadProcSafe));
                        this.DemoThread.Start();
                        break;
                    case SerialData.Eof:
                        CloseSerial();
                        break;
                }
    
    
            }
    
    
    
            void OpenSerial()
            {
                if (!Puerto.IsOpen)
                {
                    Puerto.Open();
                }
            }
    
            void CloseSerial()
            {
                if (Puerto.IsOpen)
                {
                    Puerto.Close();
                }
            }
    
            private void ThreadProcSafe()
            {
                this.SetText(buffer);
                //CloseSerial();
            }
    
            delegate void SetTextCallback(string text);
    
            private void SetText(string text)
            {
                if (this.textoRecibido.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetText);
                    this.BeginInvoke(d, new object[] { text });
                }
                else
                {
                    if (text.EndsWith("\r\n"))
                    {
                        this.textoRecibido.Text = text;
                        if (MessageBox.Show(this, text, "", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000) == DialogResult.Yes)
                        {
                            Application.Exit();
                        }
                        
                    }
                }
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }
    }
