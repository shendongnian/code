        string useracc = (string)Session["AccountNumber"];
        var accountInstance = db.Accounts
                              .FirstOrDefault(w => w.AccountNumber.ToString() == useracc);
        if (accountInstance == null) {
            return
        };
        var AccountTransactions = db
                                  .Transactions
                                  .Where(w => w.AccountId == accountInstance.Id&&w.IsCancelled ==false);
                                  .Where(w => w.TransactionTypeId == 2 && w.Date.Year >= 2015)
                                  ;
         var needDuedate = db.SystemInvoices
                             .Where(inv => AccountTransactions.Max(a =>a.Id)== inv.Id).OrderByDescending(inv => Inv.DueDate)
                             .select(inv => inv.DueDate)
                             .FirstOrDefault();
