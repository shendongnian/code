        string useracc = (string)Session["AccountNumber"];
        var accountInstance = db.Accounts.FirstOrDefault(w => w.AccountNumber.ToString() == useracc);
        if (accountInstance == null) {
            return
        };
        var AccountTransactions = db
                                  .Transactions
                                  .Where(w => w.AccountId == accountInstance.Id&&w.IsCancelled ==false);
        var accountStatement = AccountTransactions
                              .Where(w =>  w.TransactionTypeId == 2 && w.Date.Year >= 2015)
                              .OrderByDescending(w => w.Date)
                              .ToList();
        var systemInvoice = db.SystemInvoices
                              .Where(inv => accountStatement.Max(a =>a.Id)== inv.Id);
        
        var needDuedate = systemInvoice.select(inv => inv.DueDate).FirstOrDefault();
