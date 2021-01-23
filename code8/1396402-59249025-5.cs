	using GalaSoft.MvvmLight.Messaging;
	public partial class ReportsView : UserControl
	{
		public ReportsView()
		{
			InitializeComponent();
			
			// Register a listener for the "RunSSRSReport" 
			// message, called from our viewmodel. Its 
			// handler is RunSsrsReport and its data type 
			// is ReportsViewModel.
			Messenger.Default.Register<ReportsViewModel>(this, "RunSSRSReport", RunSsrsReport);
			
			DataContext = new ReportsViewModel();
		}
		// Handler to run the selected report. 
		private void RunSsrsReport(ReportsViewModel obj)
        {
			// Basic validation
            if (obj.SelectedReportVm == null || obj.SelectedReportVm.Id.Equals(-1)) 
			{
				return;
			}
		
			// Ugly switch to run the correct report.
			// It can be re-written with pattern matching.
			switch (obj.SelectedReportVm.Id)
            {
                case (int)Constants.Report.ReportA:
                    RunReportA(obj);
                    break;
                case (int)Constants.Report.ReportB:
                    RunReportB(obj);
                    break;
				// other reports....
			}
		}	
		
		// Run the report using dataset and tableadapter.
        // Modify to use your code for running the report.
		private void RunReportA(ReportsViewModel reportsViewModel)
        {
            var dataSet = new ReportADataSet();
            dataSet.BeginInit();
            // We reference the ReportViewer control in XAML.
            ReportViewer.ProcessingMode = ProcessingMode.Local;
            ReportViewer.LocalReport.ShowDetailedSubreportMessages = true;
            ReportViewer.LocalReport.DataSources.Clear();
            var dataSource = new ReportDataSource
            {
                Name = "ReportA_DS",
                Value = dataSet.uspReportA	// Uses a stored proc
            };
            ReportViewer.LocalReport.DataSources.Add(dataSource);
            ReportViewer.LocalReport.ReportEmbeddedResource =
                "MyApp.Reports.ReportA.rdlc";
            dataSet.EndInit();
            new reportATableAdapter { ClearBeforeFill = true }
                .Fill(dataSet.uspReportA);
			// Send message back to viewmodel that the report is ready.
            Messenger.Default.Send(Constants.Report.ReportA, "SsrsReportReady");
        }
	}
