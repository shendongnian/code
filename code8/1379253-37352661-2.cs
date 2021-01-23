    using System.Collections.Generic;
    using System.Windows;
    
    namespace WpfApplication55
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                reportViewer1.LocalReport.ReportEmbeddedResource = "WpfApplication55.Report1.rdlc";
    
                Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
                reportDataSource1.Name = "DataSet1";
                reportDataSource1.Value = new List<MyReportData>() { new MyReportData() { Field1 = "Value 1", Field2 = "Value 2" } };
                reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                reportViewer1.RefreshReport();
            }
        }
    
        public class MyReportData
        {
            public string Field1 { get; set; }
            public string Field2 { get; set; }
        }
    }
