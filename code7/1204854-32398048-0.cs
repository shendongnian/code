    using System.Web.UI.WebControls;
      ReportViewer reportViewer = new ReportViewer();
      reportViewer.ProcessingMode = ProcessingMode.Local;
      reportViewer.SizeToReportContent = true;
      reportViewer.Width = Unit.Percentage(100);
      reportViewer.Height = Unit.Percentage(100);
