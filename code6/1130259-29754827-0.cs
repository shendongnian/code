    class YourClassWhereYouPutTheseThings
    {
        private ManualResetEvent _mre = new ManualResetEvent(true);
        
        //...your other stuff here...
        public YourClassWhereYouPutTheseThings()
        {
            //...your existing stuff
            feed.RequestCompanyName += new IFeedEvents_RequestCompanyNameEventHandler(feed_RequestName);
            //...your existing stuff
        }
        void YourMethod()
        {
            foreach (DataLoader.GetInfo items in listBoxFetInfo.Items)
            {
                DownloadInfo(items.CompanyName);                     
            }
        }
        
        void DownloadInfo(string name)
        {
            this._mre.Reset(); //make everyone listening to _mre wait until Set is called
            int requestId = feed.SendCompanyNameRequest(symbol.ToUpper(), sendType, sendTimePeriod, sendDateFrom, DateTime.Now);
            this._mre.WaitOne(); //wait for the feed_RequestName method to be called once
        }
        
        void feed_RequestName(int originalRequestId, short ResponseCode, string symbol, short symbolStatusCode, object records)
        {
           //save to file
           //store your information on the object somewhere if you would like
           
           //after saving to your file, set the manualresetevent so that the WaitOne() above can proceed
           this._mre.Set();
        }
    }
