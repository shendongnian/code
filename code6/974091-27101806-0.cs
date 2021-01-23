    public partial class RunForm : Form
    {
        public RunForm()
        {
            InitializeComponent();
        }
        private void runButton_Click(object sender, EventArgs e)
        {
            NativeMethods.AllocConsole();
            using (Process process = new Process())
            {
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = "/c echo Hello world!";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.Start();
                process.OutputDataReceived += process_OutputDataReceived;
                process.BeginOutputReadLine();
            }
        }
        void process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine(e.Data);
            // do other things with the output here
        }
        private void closeConsoleButton_Click(object sender, EventArgs e)
        {
            NativeMethods.FreeConsole();
        }
    }
    internal static class NativeMethods
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool AllocConsole();
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool FreeConsole();
    }
