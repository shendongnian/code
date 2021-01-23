        string useracc = (string)Session["AccountNumber"];
        var accountInstance = db.Accounts.FirstOrDefault(w => w.AccountNumber.ToString() == useracc);
        if (accountInstance == null) {
            return
        };
        List<Transaction> AccountTransactions = db.Transactions.Where(w => w.AccountId == accountInstance.Id&&w.IsCancelled ==false).ToList();
        var accountStatement = AccountTransactions.Where(w =>  w.TransactionTypeId == 2 && w.Date.Year >= 2015).ToList();
        var systemInvoice = db.SystemInvoices.Where(inv => accountStatement.Max(a =>a.Id)== inv.Id).OrderByDescending(inv => inv.Date);
        
        var needDuedate = systemInvoice.select(inv => inv.DueDate).FirstOrDefault;
