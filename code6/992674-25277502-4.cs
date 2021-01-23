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
                //Add IpAddresses to the List
                addresses.Add(new IPAddress(new byte[] { 65, 55, 72, 135 }));
                addresses.Add(new IPAddress(new byte[] { 8, 8, 8, 8 })); 
                addresses.Add(new IPAddress(new byte[] { 74, 125, 157, 99 }));
                addresses.Add(new IPAddress(new byte[] { 98, 137, 149, 56 }));
            }
            private void button1_Click(object sender, EventArgs e)
            {
                //Not sure how you are passing in your list I elected to do it with a button click
                foreach (var address in addresses)
                {
                    byte[] ba = address.GetAddressBytes(); //Get the IPAddress in a Byte Format for the Button Text
                                                           //Keeping it as an IPAddress in the Tag so I don't have to convert later
                    Button b = new Button() { Tag = address, Dock = DockStyle.Fill, Text = String.Format("{0}.{1}.{2}.{3}", ba[0], ba[1], ba[2], ba[3]) };
                    tableLayoutPanel1.Controls.Add(b);
                }
            
            }
            private void tableLayoutPanel1_ControlAdded(object sender, ControlEventArgs e)
            {
                if (e.Control is Button) //Check if control is a Button.
                {     
                    //The ControlEventArgs Control Property has the Control that was added to the tableLayoutPanel
                    Ping pingIt = new Ping(); //Create the Ping Object
                    pingIt.PingCompleted += pingIt_PingCompleted;  //Add the eventHandler
                    //used the SendAsync Method that allows and object to be passed as a user token
                    //passed in the control that was added so that the background color can be changed
                    pingIt.SendAsync((IPAddress)e.Control.Tag,2000,e.Control);
                }
            
            }
            void pingIt_PingCompleted(object sender, PingCompletedEventArgs e)
            {
                Control ctrl = (Control)e.UserState;
                if (ctrl.Text != "NCAP")
                {
                    if (e.Reply.Status == IPStatus.Success)
                    {
                        ctrl.BackColor = Color.Green;
                    }
                    else
                    {
                        ctrl.BackColor = Color.Red;
                    }
                }
            }
        }
    }
