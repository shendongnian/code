    using Microsoft.Reporting.WebForms;
    namespace YourNamespace
    {
        public partial class ReportViewerWebForm : ReportViewerForMvc.ReportViewerWebForm
        {
    
            protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);
    
                ReportViewer1.LocalReport.SubreportProcessing += LocalReport_SubreportProcessing;
            }
    
    
            private void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
            {
                ReportDataSource rds = new ReportDataSource("SubReport_DatasetName_Here", yourData);
                e.DataSources.Add(rds);
            }
        }
    }
