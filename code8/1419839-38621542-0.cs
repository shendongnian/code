            searchTransaction.savedSearchId = "2017";
            SearchResult result = netsuite.search(searchTransaction);
            if(result.status.isSuccess)
            {
                SearchRow[] searchRows = result.searchRowList;
                if(searchRows != null && searchRows.Length >= 1)
                {
                    for (int i = 0; i < searchRows.Length; i++)
                    {
                        TransactionSearchRow transactionRow = (TransactionSearchRow)searchRows[i];
                        var iid = transactionRow.basic.internalId[0].searchValue;
                        double amount = transactionRow.basic.amount[0].searchValue;
                        string custfild = transactionRow.basic.customFieldList[0].scriptId;
                        SearchColumnStringCustomField custfild =  (SearchColumnStringCustomField)transactionRow.basic.customFieldList[0];
                        
                        Console.WriteLine("\n Transaction ID: " + iid.internalId);
                        Console.WriteLine("\n Amount: " + amount.ToString());
                        Console.WriteLine("\n custfild: " + custfild.searchValue);
                    }
                }
            }
