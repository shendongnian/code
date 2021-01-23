    namespace IntegrationPlanning.Controls
    {
    
    /// <summary>
    /// Логика взаимодействия для PlaningParserControl.xaml
    /// </summary>
    [Serializable]
    public partial class PlaningParserControl : UserControl
    {
        public int ParseProgressBarValue { get; set; }
        private BackgroundWorker worker = new BackgroundWorker();
        private readonly PlaningParserModel _parserModel = new PlaningParserModel();
        public PlaningParserControl()
        {
            InitializeComponent();
            worker.WorkerReportsProgress = true;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.DoWork += worker_DoWork;
        }
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (var i = 0; i < 100; i++)
            {
                Thread.Sleep(150);
                worker.ReportProgress(i);
            }
        }
        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ParseProgressBar.Value = e.ProgressPercentage;;
        }
        private void AddFileButton_OnClick(object sender, RoutedEventArgs e)
        {
            var excelApplication = new Excel.Application();
            var openFileDialog = new OpenFileDialog {Filter = "excel files(*.xls)(*.xlsx)|*.xls;*.xlsx" };
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName.EndsWith(".xls") || openFileDialog.FileName.EndsWith(".xlsx"))
            {
                ParseProgressBar.Value = 0;
                worker.RunWorkerAsync();
                var t = Task.Run(() =>
                {
                    _parserModel.Workbook = excelApplication.Workbooks.Add(openFileDialog.FileName);
                    _parserModel.ParseTpSheet();
                });
            }
            else
            {
                MessageBox.Show("Файл не был выбран", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            excelApplication.Quit();
        }
    }
    }
