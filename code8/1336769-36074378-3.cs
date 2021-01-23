        string useracc = (string)Session["AccountNumber"];
        var accountInstance = db.Accounts
                              .FirstOrDefault(w => w.AccountNumber.ToString() == useracc);
        if (accountInstance == null) {
            return
        };
        var lastTransactionId = db
                                  .Transactions
                                  .Where(w => w.AccountId == accountInstance.Id&&w.IsCancelled ==false);
                                  .Where(w => w.TransactionTypeId == 2 && w.Date.Year >= 2015)
                                  .Max(t => t.Id)
                                  ;
         var needDuedate = db.SystemInvoices
                             .Where(inv =>  lastTransactionId == inv.Id)
                             .OrderByDescending(inv => Inv.DueDate)
                             .select(inv => inv.DueDate)
                             .FirstOrDefault();
