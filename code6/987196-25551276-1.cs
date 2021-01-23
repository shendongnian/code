    public partial class Form1 : Form
    {
        string fileName = "c:\\temp\\tempoutput.txt";
        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler
                    (backgroundWorker1_ProgressChanged);
 
        }
        void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // This function fires on the UI thread so it's safe to edit the UI control directly
            progressBar1.Value = e.ProgressPercentage;
            readTempFile();
            //outputTextArea.Text = "Processing......" + progressBar1.Value.ToString() + "%";
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // command line
            string[] args = e.Argument as string[];
            backgroundWorker1.ReportProgress(2);
 
            try
            {
                FileStream fs = File.Open(fileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine("### Starting the process : ###");
                sw.Flush();
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.WorkingDirectory = "WorkdirPath";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.FileName = "cmd.exe";
                // create the command line
                int nArgs = args.Length;
                if (nArgs > 0)
                {
                    process.StartInfo.Arguments = args[0];
                }
                for (int i = 1; i < nArgs; i++)
                {
                    process.StartInfo.Arguments = String.Concat(process.StartInfo.Arguments, " && ", args[i]);
                }
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                backgroundWorker1.ReportProgress(5);
                process.Start();
                backgroundWorker1.ReportProgress(10);
                System.IO.StreamWriter sIn = process.StandardInput;
                System.IO.StreamReader sOut = process.StandardOutput;
                backgroundWorker1.ReportProgress(15);
                int timeCount = 15;
                string tempOut = "";
                while (!sOut.EndOfStream)
                {
                    tempOut = sOut.ReadLine();
                    sw.WriteLine(tempOut);
                    sw.Flush();
                    if (timeCount < 90)
                    {
                        // increasing the progress bar value.
                        //timeCount += 1;
                    }
                    backgroundWorker1.ReportProgress(timeCount);
                }
                sw.WriteLine("Closing process");
                sw.Flush();
                process.Close();
                backgroundWorker1.ReportProgress(100);
            }
            catch (System.IO.IOException exept)
            {
                Console.WriteLine(exept.Message);
                return;
            } 
        }
        
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            readTempFile();
        }
        private void readTempFile()
        {
            try
            {
                FileStream fs = File.Open(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
                StreamReader r = new StreamReader(fs);
                string output = r.ReadToEnd();
                outputTextArea.Text = output;
            }
            catch (System.IO.IOException exept)
            {
                Console.WriteLine(exept.Message);
                return;
            }
        }
    }
