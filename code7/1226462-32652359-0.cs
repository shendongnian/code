    using System;
    using System.Text;
    using System.Windows.Forms;
    using System.Diagnostics;
    
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
    			process.StartInfo.FileName = @"c:/req/dist/ex/ex.exe";
    			process.StartInfo.CreateNoWindow = true;
    			process.StartInfo.UseShellExecute = false;
    			process.StartInfo.RedirectStandardOutput = true;
    			process.OutputDataReceived += OnOutputDataReceived;
    			process.Exited += OnProcessExited;
    			process.Start();
    			process.BeginOutputReadLine();
    		}
    
    		private void OnOutputDataReceived(object sender, DataReceivedEventArgs e)
    		{
    			lock (syncGate)
    			{
    				if (sender != process) return;
    				output.AppendLine(e.Data);
    				if (outputChanged) return;
    				outputChanged = true;
    				BeginInvoke(new Action(OnOutputChanged));
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
    
    		private void OnProcessExited(object sender, EventArgs e)
    		{
    			lock (syncGate)
    			{
    				if (sender != process) return;
    				process.Dispose();
    				process = null;
    			}
    		}
    	}
    }
