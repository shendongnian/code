    private async Task GetInvoicesAsync()
    {
      IsOperationRunning = true; //Binding for a RadBusyIndicator
      Invoices = await Task.Run(() => _uiContractService.GetInvoices(SelectedInvoiceState, SelectedSupplierItem.Id, SelectedInvoiceDateFilter, FilterStartDate, FilterEndDate));
      IsOperationRunning = false;
      RaisePropertyChanged(() => Invoices);
      if (Invoices.Count == 0)
        SendUserInfoMsg($"NO invoices matched your search criteria.", UiUserNotificationMessageType.Warning);
    }
