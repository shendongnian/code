    public Form1()
        {
            InitializeComponent();
            _open.Click += new EventHandler(_open_Click_1);
        }
        private void _open_Click_1(object sender, EventArgs e)
        {
            _openFile = new OpenFileDialog();
            _playList.Items.Clear();
            _openFile.Multiselect = true;
            _openFile.Filter = "Mp3 Files|*.mp3|Avi Files|*.avi|Mp4 Files|*.mp4";
            _openFile.ShowDialog();
            var doc = _openFile.SafeFileNames;
            var path = _openFile.FileNames;
            for (int i = 0; i < doc.Length; i++)
            {
                _playList.Items.Add(doc[i]);
            }
        }
