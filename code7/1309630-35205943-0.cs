    using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Drawing;
	using System.Linq;
	using System.Text;
	using System.Windows.Forms;
	using System.IO.Ports;
	namespace FieldProbe
	{
		public partial class MainForm : Form
		{
			private var port = new SerialPort(portName);
			public MainForm()
			{
				InitializeComponent();
			}
			private void MainForm_Load(object sender, EventArgs e)
			{
				var ports = SerialPort.GetPortNames();
				cmbSerialPorts.DataSource = ports;
			}
			private void btnConnect_Click(object sender, EventArgs e)
			{
				if (btnConnect.Text == "Connect")
				{
					btnConnect.Text = "Disconnect";
					if (cmbSerialPorts.SelectedIndex > -1)
					{
						MessageBox.Show(String.Format("You selected port '{0}'", cmbSerialPorts.SelectedItem));
						Connect(cmbSerialPorts.SelectedItem.ToString());
					}
					else
					{
						MessageBox.Show("Please select a port first");
					}
				}
				else
				{
					btnConnect.Text = "Connect";
					port.Close();
				}
			}
			private void Connect(string portName)
			{
				if (!port.IsOpen)
				{
					port.BaudRate = 921600;
					port.DataBits = 8;
					port.StopBits = StopBits.One;
					port.Parity = Parity.None;
					port.Handshake = Handshake.None;
					port.Open();
				}
			}
			private void OtherFunction()
			{
				if (port == null || !port.IsOpen)
					return;
				
				// HERE DO WHATEVER YOU WANT WITH port
			}
		}
	}
