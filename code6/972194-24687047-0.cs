    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Diagnostics;
    using System.IO;
    
    
    namespace ConsoleTest_07_07_14
    {
        public partial class Form1 : Form
        {
            delegate void SetTextCallBack(string text);
            Process proc1 = new Process();
            string proc1_OutputText;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                SetProc1();
            }
    
            public void SetProc1()
            {
                proc1.StartInfo.FileName = @"C:\Windows\System32\cmd.exe";
                proc1.StartInfo.WorkingDirectory = @"C:\Windows";
                proc1.StartInfo.UseShellExecute = false;
                proc1.StartInfo.CreateNoWindow = true;
                proc1.StartInfo.RedirectStandardInput = true;
                proc1.StartInfo.RedirectStandardError = true; //why was it false??
                proc1.StartInfo.RedirectStandardOutput = true;
                proc1.OutputDataReceived += new DataReceivedEventHandler(MyProc1OutputHandler);
                proc1.ErrorDataReceived += new DataReceivedEventHandler(MyProc1OutputHandler);
                proc1.Start();
                proc1.BeginOutputReadLine();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                // send command to process1
                clearProc1_text();
                SendProcessCommand(proc1, textBox2.Text);
            }
    
            private void SendProcessCommand (Process proc, string text)
            {
                StreamWriter SW = proc.StandardInput;
                SW.WriteLine(text);
            }
    
            private void setProc1_OutputText(string text)
            {
                if (this.textBox1.InvokeRequired)
                {
                    SetTextCallBack d = new SetTextCallBack(setProc1_OutputText);
                    this.Invoke(d, new object[] { text });
                }
                else 
                {
                    proc1_OutputText += text + Environment.NewLine;
                    this.textBox1.Text = proc1_OutputText; 
                }
            }
    
            private void clearProc1_text ()
            {
                clearText1();
                clearProc1_OutputText();
            }
    
            private void clearText1() { textBox1.Text = ""; }
            private void clearProc1_OutputText() { proc1_OutputText = ""; }
    
            private static void MyProc1OutputHandler(object sendingProcess, DataReceivedEventArgs outline)
            {
                Debug.Print("Called");
                if (!String.IsNullOrEmpty(outline.Data))
                { //Debug.Print(outline.Data)
                    Form1 f = (Form1)Form.ActiveForm;
                    if (f != null)
                    {
                        f.setProc1_OutputText(outline.Data);
                    }
                }
            }
    
        }
    }
