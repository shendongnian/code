    private static  void OnQueryComplete(IAsyncResult result)
    {
            DataServiceQuery<TMLiveData.JobType> query = result.AsyncState as DataServiceQuery<TMLiveData.JobType>;
            mResult = "Done!";
            try
            {
                foreach (TMLiveData.JobType jobType in query.EndExecute(result))
                {
                    mResult += jobType.JobType1 + ",";
                }
            }
            catch (Exception ex)
            {
                mResult = "Error looping for items: " + ex.Message;
            }
    }
