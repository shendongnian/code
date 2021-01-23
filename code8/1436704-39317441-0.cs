    DateTime startDate =    Convert.ToDateTime(dateEdtStartDate.EditValue).Date;
    DateTime endDate = Convert.ToDateTime(dtpEditEndDate.EditValue).Date;
    private DetailReportFCBuySell FetchRecord ()
    {
    return ObservableCollection<DLReports.FCBuySellDetail> temp = AlyexWCFService.DL.DLTTIn.FCBuySELL(transactionName, isDetails, startDate, endDate, Customerid, ProductID, branchID, NoOfRecords, PageIndex - 1, isBuy);
    }
