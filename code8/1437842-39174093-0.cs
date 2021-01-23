    public async Task<ObservableCollection<InvoiceDto>> GetInvoicesAsync(InvoiceState invoiceState, Guid supplierId, UiInvoiceDateFilters dateType, DateTime begin, DateTime end)
    {
        return await Task.Run( () =>
        {
             return GetInvoicesAsync(invoiceState, supplierId, dateType, begin, end);
         });
    }
