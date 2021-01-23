    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private TaskCompletionSource<bool> _cancelTask;
        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = true;
            _cancelTask = new TaskCompletionSource<bool>();
            try
            {
                await RunProcess();
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("The operation was cancelled");
            }
            finally
            {
                _cancelTask = null;
                button1.Enabled = true;
                button2.Enabled = false;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            _cancelTask.SetCanceled();
        }
        private async Task RunProcess()
        {
            Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/C pause",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = false,
                }
            };
            process.Start();
            Task readerTasks = Task.WhenAll(
                ConsumeReader(process.StandardError),
                ConsumeReader(process.StandardOutput));
            Task completedTask = await Task.WhenAny(readerTasks, _cancelTask.Task);
            if (completedTask == _cancelTask.Task)
            {
                process.Kill();
                await readerTasks;
                throw new TaskCanceledException(_cancelTask.Task);
            }
        }
        private async Task ConsumeReader(TextReader reader)
        {
            char[] text = new char[512];
            int cch;
            while ((cch = await reader.ReadAsync(text, 0, text.Length)) > 0)
            {
                textBox1.AppendText(new string(text, 0, cch));
            }
        }
    }
