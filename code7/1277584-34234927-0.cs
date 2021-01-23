    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Diagnostics;
    
    namespace WindowsFormsApplication5
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            
            private void Form1_Load(object sender, EventArgs e)
            {
                Process p = new Process();
                p.StartInfo.FileName = @"C:\loop.exe";
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.UseShellExecute = false;
                p.Start();
                p.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);
                p.BeginOutputReadLine();
            }
    
            void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
            {
                label1.Invoke((MethodInvoker)delegate
                {
                    label1.Text = e.Data; // runs on UI thread
                });
            }
        }
    }
