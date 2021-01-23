    private void btnAllStatusPrint_Click(object sender, RoutedEventArgs e)
    {
        if (RedeemVoucherViewModel.EgmList.Count != 0)
        {
            Report reportObj = new Report();
            // set scale mode
            reportObj.ReportSettings.HorizontalPaginationMode = HorizontalPaginationMode.Scale;
            reportObj.PageHeaderTemplate = this.Resources["PagePresenterHeaderTemplate_small"] as DataTemplate;
            string siteControllerName = RedeemVoucherView.getSiteControllerName();
            reportObj.PageFooter = string.Format("Total Machines: {0}", MyXamDataGrid.DataItems.Count);
            reportObj.PageHeader = string.Format("{0} {2} {1}", siteControllerName, DateTime.Now.ToString("dd/MM/yyyy"), Environment.NewLine);
            reportObj.ReportSettings.PageSize = new Size(3.13, 6);
            // create section and add it to report's section collection
            reportObj.ReportSettings.Margin = new Thickness(0, 0, 0, 0);
            EmbeddedVisualReportSection section = new EmbeddedVisualReportSection(datagdStatus);
            reportObj.Sections.Add(section);
            var xamReportPreviewToGetTotalPageNumbers = new XamReportPreview();
            xamReportPreviewToGetTotalPageNumbers.GeneratePreview(reportObj, false, false);
            reportObj.PageFooterTemplate = GetDataTemplateForTotalPageNumbers(reportObj.PhysicalPageNumber);
            reportObj.Print(true, false);
            rteventLogger.WriteLog(TraceEventType.Information, "All Status report is printed", WMSTrace.ScopeTypes.Internal);
        }
        else
        {
            MessageBoxHelper.Show("No content available to print", MessageBoxImage.Information);
        }
    }
