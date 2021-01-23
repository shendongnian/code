    public void GetInvoiceList()
        {
            TransactionSearch transactionsSearch = new TransactionSearch();
            TransactionSearchBasic transactionSearchBasic = new TransactionSearchBasic();
            transactionSearchBasic.type = new SearchEnumMultiSelectField();
            transactionSearchBasic.type.@operator = SearchEnumMultiSelectFieldOperator.anyOf;
            transactionSearchBasic.type.operatorSpecified = true;
            transactionSearchBasic.type.searchValue = new string[] { "_invoice" };
            transactionsSearch.basic = transactionSearchBasic;
            this.login(true);
            SearchResult result = _service.search(transactionsSearch);
            List<Invoice> invoiceList = new List<Invoice>();
            if (result.status.isSuccess)
            {
                //RecordList recordList = result.recordList;
                Record[] records = result.recordList;
                if (records != null && records.Length != 0)
                {
                    for (int i = 0; i < records.Length; i++)
                    {
                        Invoice invoice = (Invoice)records[i];
                        invoiceList.Add(invoice);
                    }
                }
            }
            Console.ReadLine();
        }
