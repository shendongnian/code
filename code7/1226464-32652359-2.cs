    using System;
    using System.Text;
    using System.Windows.Forms;
    using System.Diagnostics;
    using System.Threading;
    
    namespace WindowsFormsApplication1
    {
    	public partial class Form1 : Form
    	{
    		public Form1()
    		{
    			InitializeComponent();
    		}
    
    		private object syncGate = new object();
    		private Process process;
    		private StringBuilder output = new StringBuilder();
    		private bool outputChanged;
    
    		private void button1_Click(object sender, EventArgs e)
    		{
    			lock (syncGate)
    			{
    				if (process != null) return;
    			}
    
    			output.Clear();
    			outputChanged = false;
    			richTextBox1.Text = "";
    
    			process = new Process();
    			process.StartInfo.FileName = @"C:\Users\Ivan Stoev\AppData\Local\Temporary Projects\ConsoleApplication1\bin\Debug\ConsoleApplication1.exe";
    			process.StartInfo.CreateNoWindow = true;
    			process.StartInfo.UseShellExecute = false;
    			process.StartInfo.RedirectStandardOutput = true;
    			process.Start();
    
    			new Thread(ReadData) { IsBackground = true }.Start();
    		}
    
    
    		private void ReadData()
    		{
    			var input = process.StandardOutput;
    			int nextChar;
    			while ((nextChar = input.Read()) >= 0)
    			{
    				lock (syncGate)
    				{
    					output.Append((char)nextChar);
    					if (!outputChanged)
    					{
    						outputChanged = true;
    						BeginInvoke(new Action(OnOutputChanged));
    					}
    				}
    			}
    			lock (syncGate)
    			{
    				process.Dispose();
    				process = null;
    			}
    		}
    
    		private void OnOutputChanged()
    		{
    			lock (syncGate)
    			{
    				richTextBox1.Text = output.ToString();
    				outputChanged = false;
    			}
    		}
    	}
    }
