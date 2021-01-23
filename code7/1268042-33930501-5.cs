    public partial class Form1 : Form
    {
        string usedPath = @"C:\Users\xxx\Desktop\usedwords.txt";
        public Form1()
        {
            InitializeComponent();
            watch();
        }
        private void watch()
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = Path.GetDirectoryName(usedPath);
            watcher.Filter = Path.GetFileName(usedPath);
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.EnableRaisingEvents = true;
        }
        private void OnChanged(object source, FileSystemEventArgs e)
        {
            Thread.Sleep(10);
            Invoke((MethodInvoker)delegate
            {
                richTextBox1.LoadFile(usedPath, RichTextBoxStreamType.PlainText);
            });
        }
    }
