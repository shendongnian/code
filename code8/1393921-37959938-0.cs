    using QBXMLRP2Lib;
    using Interop.QBFC13;
    public class SDKApp
    {
        private QBSessionManager sessionMgr;
        public SDKApp()
        {
            // in the class constructor - sessionMgr is a member variable
            sessionMgr = new QBSessionManager(); 
        }
        public void GetCreditMemoData()
        {
            // open connection and begin session before data fetch - intentionally skipped this code
            IMsgSetRequest msgset = null;
            ICreditMemoQuery creditMemoQuery = null;
            try
            {
                // during data fetch
                msgset = sessionMgr.CreateMsgSetRequest("US", 13, 0);
                creditMemoQuery = msgset.AppendCreditMemoQueryRq();
                creditMemoQuery.ORTxnQuery.TxnFilter.ORDateRangeFilter.ModifiedDateRangeFilter.FromModifiedDate.SetValue(new DateTime(2012, 3, 31), false); // you can apply filters too
                IMsgSetResponse msgRes = sessionMgr.DoRequests(msgset);
                IResponseList responseList = msgRes.ResponseList;
                if (responseList.Count > 0)
                {
                    IResponse response = responseList.GetAt(0);
                    ICreditMemoRetList creditMemoList = response.Detail as ICreditMemoRetList;
                    if (creditMemoList == null)
                    {
                        return;
                    }
                    for (int i = 0; i <= creditMemoList.Count - 1; i++)
                    {
                        ICreditMemoRet qbCreditMemo = creditMemoList.GetAt(i);
                        Console.WriteLine("Credit no.:" + qbCreditMemo.TxnNumber.GetValue() + " Customer:" + qbCreditMemo.CustomerRef.FullName.GetValue() + " Total:" + qbCreditMemo.TotalAmount.GetValue());
                    }
                }
            }
            catch (Exception ex)
            {
                //handle exception here
            }
            finally
            {
                if (msgset != null)
                {
                    Marshal.FinalReleaseComObject(msgset);
                }
                if (creditMemoQuery != null)
                {
                    Marshal.FinalReleaseComObject(creditMemoQuery);
                }
            }
            // end session and close connection after data fetch - intentionally skipped this code
        }
    }
