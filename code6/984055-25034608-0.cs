    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace Casper
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
    
                string Cpath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                //;C:\phantomjs;C:\casperjs\batchbin
                FileInfo csp1 = new FileInfo(Cpath + @"\tools\casperjs\n1k0-casperjs-4f105a9\bin\casperjs");
                FileInfo csp2 = new FileInfo(Cpath + @"\tools\casperjs\n1k0-casperjs-4f105a9\batchbin");
                FileInfo pht = new FileInfo(Cpath + @"\tools\phantomjs\phantomjs-1.9.7-windows\");
                string EnvPath = string.Format(";{0};{1}", pht, csp2);
    
                DirectoryInfo dir = csp1.Directory;
                FileInfo path = new FileInfo(@"C:\Python34\python.exe");
    
                string arg = String.Format("casperjs OSTESTcasper.js");
                ExecutePythonScript(dir, path, arg, EnvPath);
    
            }
    
            private static void ExecutePythonScript(DirectoryInfo workingDir, FileInfo pythonPath, string casperArguments, string EnvPath)
            {
                var p = new Process();
                p.StartInfo.EnvironmentVariables["PATH"] = EnvPath;
                p.StartInfo.WorkingDirectory = workingDir.FullName;
                p.StartInfo.FileName = pythonPath.FullName;
                p.StartInfo.Arguments = casperArguments;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
    
                p.ErrorDataReceived += (s, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                        MessageBox.Show("e> " + e.Data);
                };
    
                p.OutputDataReceived += (s, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                        MessageBox.Show("->" + e.Data);
                };
    
                p.Start();
                p.BeginOutputReadLine();
                p.BeginErrorReadLine();
                p.WaitForExit();
                p.Close();
            }
    
        }
    
    }
