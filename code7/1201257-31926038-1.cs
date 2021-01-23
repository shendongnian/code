    private SpeechRecognizer reco;
        public MainWindow()
        {
            InitializeComponent();
            reco = new SpeechRecognizer();
            List<string> constraints = new List<string>();
            constraints.Add("Yes");
            constraints.Add("No");
            reco.Constraints.Add(new SpeechRecognitionListConstraint(constraints));
            IAsyncOperation<SpeechRecognitionCompilationResult> op = reco.CompileConstraintsAsync();
            op.Completed += HandleCompilationCompleted;
        }
        public void HandleCompilationCompleted(IAsyncOperation<SpeechRecognitionCompilationResult> opInfo, AsyncStatus status)
        {
            if(status == AsyncStatus.Completed)
            {
                System.Diagnostics.Debug.WriteLine("CompilationCompleted");
                var result = opInfo.GetResults();
                System.Diagnostics.Debug.WriteLine(result.Status.ToString());
            }
        }
