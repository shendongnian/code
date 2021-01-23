    private static SendedInvoice InitSendedInvoiceModel(InvoiceData data, int historyId, bool isFreelance)
    {
        var sendedInvoice = new SendedInvoice
                                {
                                    CompanyId = isFreelance ? null : data.CustomerId,
                                    SendingHistoryId = historyId,
                                    CourierId = isFreelance ? data.CustomerId : null
                                };
        return sendedInvoice;
    }
