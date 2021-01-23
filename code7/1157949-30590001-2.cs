    private BackgroundWorker _Worker;
    public Form1()
    {
        InitializeComponent();
        // Maybe other stuff you initialize within the ctor...
        _Worker = new BackgroundWorker();
        _Worker.DoWork += OnWorkerDoWork;
        _Worker.ProgressChanged += OnWorkerProgressChanged;
        _Worker.RunWorkerCompleted += OnWorkerRunWorkerCompleted;
        _Worker.WorkerSupportsCancellation = true;
        _Worker.WorkerReportsProgress = true;
    }
    private void bn_Start_Click(object sender, EventArgs e)
    {
        string drive;
        if (checkbox1.Checked)
        {
            if (string.IsNullOrEmpty(cmb_drive.Text))
            {
                drive = "-";
                return;
            }
            else
            {
                drive = cmb_drive.GetItemText(cmb_drive.SelectedItem);
            }
            if (_Worker.IsBusy)
            {
                _Worker.CancelAsync();
                // ToDo: Update gui by disable buttons, etc and show that cancelation is pending.
                //       The enabling of the buttons, etc should happen in OnWorkerRunWorkerCompleted()
                return;
            }
            var rootFolder = Path.Combine(drive + ":", "Foldername1");
            var outputFolder = Path.Combine(rootFolder, @"Foldername2");
            var solutions = GetAvailableSolutions(rootFolder);
            var arguments = solutions.Select(solution => String.Join(" ", solution, "/build Release", "/out " + outputFolder));
            var processes = arguments.Select(CreateMsBuildProcess);
            // ToDo: Disable start button and update gui that processing has started.
            // btn_Start.Enabled = false;
            ClearFolder(outputFolder);
            _Worker.RunWorkerAsync(processes);
        }
    }
