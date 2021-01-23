    public static int AddCODCustomerOrderTransaction(TransactionUpdate transaction)
            {
                try
                {
                    using (WMSDataContext dc = new WMSDataContext())
                    {
                        TransactionUpdate objtransactionAddCOD = new TransactionUpdate();
                        objtransactionAddCOD = transaction;
    		    var newTransactionUpdateID = dc.TransactionUpdates.Max(s = >s.TransactionUpdateId);
    
    		    objtransactionAddCOD.TransactionUpdateId = newTransactionUpdateID == null ? 1: (newTransactionUpdateID + 1);
                        dc.TransactionUpdates.InsertOnSubmit(objtransactionAddCOD);
                        dc.SubmitChanges();
                        return 1;
                    }
                }
                catch (Exception ex)
                {
                    clsError.WriteError(ex);
                    return -1;
                }
            }
