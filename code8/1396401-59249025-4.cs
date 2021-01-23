	using GalaSoft.MvvmLight.Messaging;
	public class ReportsViewModel : MyAppViewModelBase
	{
        public ReportsViewModel()
        {
			// Register a listener that receives the enum of the 
			// report that's ready. The message it receives has 
			// name "SsrsReportReady" with handler SsrsReportReady.
            Messenger.Default.Register<Constants.Report>(this, "SsrsReportReady", SsrsReportReady);
			// Other logic...
		}
		
		// Bound to a button to run the selected report
		public ICommand RunReportRelayCommand =>
					new RelayCommand(RunReport);
		// Backing field for the selected report.
        private ReportViewModel _selectedReportVm;
		public ReportViewModel SelectedReportVm
        {
            get { return _selectedReportVm; }
            set
            {
                if (Equals(value, _selectedReportVm)) return;
                _selectedReportVm = value;
				
				// Built-in method from Light Toolkit to 
				// handle INotifyPropertyChanged
                RaisePropertyChanged();	 
            }
        }
			
		private void RunReport()
		{
			// Send a message called "RunSSRSReport" with this VM attached as its data.
			Messenger.Default.Send(this, "RunSSRSReport");
		}
		// Handler for report-ready
		private void SsrsReportReady(Constants.Report obj)
        {
            ShowReport = true;
            IsRunReportButtonEnabled = true;
            RunReportButtonContent = Constants.BtnGenerateReport;
			
			// View uses Material Design's Expander control.
			// We expand/collapse sections of the view.
            ExpandReport = true;
            ExpandParameters = false;
        }
	}
	
