    internal class SamplesAnalyzeCommand : ICommand {
       ...
       public void Execute(object parameter)
       {
           this._viewModel.ShowProcessOptions(parameter);
       }
    }
    internal class CachedDataSummaryViewModel {
        public string Status {
             get {
                 return this.status;
             }
             set {
                 if (!string.Equals(this.status, value)) {
                     this.status = value;
                     // Notify property change to UI
                 }
             }
        }
        ...
        internal void ShowProcessOptions(object paramter) {
            // Model
            var processOptions = new ProcessOptionsModel() {
                otherInfo = parameter
            };
            // View-Model
            var processOptionsViewModel = new ProcessOptionsViewModel();
            processOptionsViewModel.Model = processOptions;
            // View
            var processOptionsView = new ProcessOptionsView(
                processOptionsViewModel
            );
            // Edit2: Update status
            this.Status = "Selecting process options...";
            // You can use the event handler or dialog result
            processOptionsViewModel.OK += this.PerformProcess;
            processOptionsView.ShowDialog();
        }
        private void PerformProcess(object sender, EventArgs e) {
            var processOptionsView = sender as ProcessOptionsView;
            var processOptionsModel = processOptionsView.Model;
            var processOptions = processOptionsModel.Model;          
            // Edit2: Update status
            this.Status = "Performing process...";
            // use processOptions.OtherInfo for initial info
            // use processOptions.* for process options info
            // and perform the process here
            // Edit2: Update status
            this.Status = "Process Done.";
        }
        ...
    }
    class ProcessOptionsModel {
        public object OtherInfo {
            get;
            set;
        
        public int Parameter1 {
            get;
            set;
        }
        public IList<ProcessItem> SelectedItems {
            get;
            set;
        }
        ...
    } 
    class ProcessOptionsViewModel {
        public event EventHandler OK;
        private SamplesAnalyzeCommand model;
        private ICommand okCommand;
        public ProcessOptionsViewModel() {
             this.okCommand = new OKCommand(this.OnOK);
        }
        public SamplesAnalyzeCommand Model {
            get {
                return model;
            }
            set {
                this.model = value;
                // Property changed stuff here
            }
        }
        private void OnOK(object parameter) {
            if (this.OK != null) {
                this.OK = value;
            }
        }
    }
    class ProcessOptionsView {
         // Interacts with it's view-model and performs OK command if
         // user pressed OK or something
    }
