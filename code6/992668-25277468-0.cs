    using System;
    using System.Linq;
    using System.Windows.Forms;
    using System.Net;
    using System.Collections.Generic;
    namespace WindowsFormsApplication1
    {
      public partial class Form1 : Form
       {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            List<IPAddress> addresses;
            
            IPHostEntry heserver = Dns.GetHostEntry("192.168.1.254");
            addresses = heserver.AddressList.ToList();
            int count = 0;
            this.ControlAdded += new  System.Windows.Forms.ControlEventHandler(this.button_added);
            foreach (var addr in addresses)
            {
                count += 1;
                Button b = new Button();
                b.Name = "button1";
                b.Text = addr.ToString();
                b.Size = new System.Drawing.Size(100 + ((count-1) * 100), 50);
                b.Click += new System.EventHandler(button1_Click);
                this.Controls.Add(b);
            }           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button 1 clicked");
        }
        private void button_added(object sender, EventArgs e)
        {
            MessageBox.Show("Button 1 added");
        }
      
      }
    }
