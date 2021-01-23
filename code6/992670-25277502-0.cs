    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Net;
    using System.Net.NetworkInformation;
    namespace WindowsFormsApplication75
    {
       public partial class Form1 : Form
       {
            List<IPAddress> addresses = new List<IPAddress>();
            public Form1()
            {
                InitializeComponent();
                addresses.Add(new IPAddress(new byte[] { 8, 8, 8, 8 }));
                addresses.Add(new IPAddress(new byte[] { 74, 125, 157, 99 }));
                addresses.Add(new IPAddress(new byte[] { 98, 137, 149, 56 }));
                addresses.Add(new IPAddress(new byte[] { 65, 55, 72, 135 }));
            }
            private void button1_Click(object sender, EventArgs e)
            {
                foreach (var address in addresses)
                {
                    byte[] ba = address.GetAddressBytes();
                    Button b = new Button() { Tag = address, Dock = DockStyle.Fill, Text = String.Format("{0}.{1}.{2}.{3}", ba[0], ba[1], ba[2], ba[3]) };
                    tableLayoutPanel1.Controls.Add(b);
                }
            
            }
            private void tableLayoutPanel1_ControlAdded(object sender, ControlEventArgs e)
            {
                Ping pingIt = new Ping();
                pingIt.PingCompleted += pingIt_PingCompleted;
                pingIt.SendAsync((IPAddress)e.Control.Tag,2000,e.Control);
            
            }
            void pingIt_PingCompleted(object sender, PingCompletedEventArgs e)
            {
                if(e.Reply.Status == IPStatus.Success)
                {
                    ((Control)e.UserState).BackColor = Color.Green;
                }
                else
                {
                    ((Control)e.UserState).BackColor = Color.Red;
                }
            }
        }
    }
