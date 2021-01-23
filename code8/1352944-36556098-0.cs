            IMsgSetRequest requestMsgSet = qbSessionManager.CreateMsgSetRequest("UK", 13, 0);
            ISalesReceiptQuery salesReceiptQuery = requestMsgSet.AppendSalesReceiptQueryRq();
            salesReceiptQuery.metaData.SetValue(ENmetaData.mdNoMetaData);
            salesReceiptQuery.IncludeRetElementList.Add("Memo");
            IMsgSetResponse responseMsgSet = qbSessionManager.DoRequests(requestMsgSet);
            IResponse response = responseMsgSet.ResponseList.GetAt(0);
                       
            ISalesReceiptRetList salesReceiptRetList = (ISalesReceiptRetList)response.Detail;
            for (int i = 0; i < salesReceiptRetList.Count; i++)
            {
                if (salesReceiptRetList.GetAt(i).Memo != null)
                {
                    string memo = salesReceiptRetList.GetAt(i).Memo.GetValue();
                    if (memo != string.Empty)
                    {
                        ExistingOrderIds.Add(memo);
                    } 
                }
            }
