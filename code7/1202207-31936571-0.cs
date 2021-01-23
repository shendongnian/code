    private static SendedInvoice InitSendedInvoiceModel(InvoiceData data, int historyId, bool isFreelance)
    {
        var sendedInvoice = new SendedInvoice
                                {
                                    CompanyId = isFreelance ? 0 : data.CustomerId,
                                    SendingHistoryId = historyId,
                                    CourierId = isFreelance ? data.CustomerId : 0
                                };
        return sendedInvoice;
    }
