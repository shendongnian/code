     String TxnLOC = null;
                    IsTransactionLocation= false;
                    if (line.Contains("TRANSACTION LOC:"))
                    {
                        IsTransactionLocation = true;
                        if (IsTransactionLocation)
                        {
                            TxnLOC = line.Replace("TRANSACTION LOC:", String.Empty).Trim();
                            Console.WriteLine("The Transaction Location: ********");
                            Console.WriteLine(TxnLOC);
                        //Database insertion fot TTransaction Table
                        TTransaction txn = new TTransaction();
                        txn.TRN = txnNo;
                        txn.Amount = Convert.ToDecimal(Amount);
                        txn.TransactionLocation = TxnLOC;
                        context.TTransaction.Add(txn); //Adding to the database
                        context.SaveChanges();
                        IsTxnSection = false;//For 1 to many relationship
                        
                    }
          
                   }
