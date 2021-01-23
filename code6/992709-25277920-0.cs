	public partial class rehab : Form
	{
		private string portName = "COM1";
		private const int baudRate = 9600;
		public Form1()
		{
			InitializeComponent();
			//TODO: Simplify your UI by dynamically creating the COM port names.
			//      Get the list of available ports on the computer via the following:
			//var portNames = SerialPort.GetPortNames();
			// Call this to initially mark 'COM1' as checked.
			UpdatePortCheckmarks();
		}
		private void conndToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var textToSend = this.textBox1.Text;
			// Use a try-catch block to log any exceptions that occur.
			try
			{
				// Use a using block to close and dispose of the serial port
				// resource automatically. Also, note that the SerialPort
				// constructor takes the port name and baud rate here.
				// There are also overloads that let you pass the number of
				// data bits, parity, and stop bits, if needed.
				using (var serialPort = new SerialPort(portName, baudRate))
				{
					// Open the port before writing to it.
					serialPort.Open();
					// Send the content of the textbox (with a newline afterwards).
					serialPort.WriteLine(textToSend);
				}
			}
			catch (Exception ex)
			{
				// You could also use MessageBox.Show. Console.WriteLine will
				// display errors in your debugger's output window.
				Console.WriteLine("ERROR: " + ex.ToString());
			}
		}
		private void cOM1ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			portName = "COM1";
			UpdatePortCheckmarks();
		}
		private void cOM2ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			portName = "COM2";
			UpdatePortCheckmarks();
		}
		// .. and so on for each additional port menu item (COM3 through COM10)
		// This method lets you share the code for updating the checkmarks on
		// the menu items, so your form code will be cleaner.
		private void UpdatePortCheckmarks()
		{
			cOM1ToolStripMenuItem.Checked = portName == "COM1";
			cOM2ToolStripMenuItem.Checked = portName == "COM2";
			cOM3ToolStripMenuItem.Checked = portName == "COM3";
			cOM4ToolStripMenuItem.Checked = portName == "COM4";
			cOM5ToolStripMenuItem.Checked = portName == "COM5";
			cOM6ToolStripMenuItem.Checked = portName == "COM6";
			cOM7ToolStripMenuItem.Checked = portName == "COM7";
			cOM8ToolStripMenuItem.Checked = portName == "COM8";
			cOM9ToolStripMenuItem.Checked = portName == "COM9";
			cOM10ToolStripMenuItem.Checked = portName == "COM10";
		}
	}
