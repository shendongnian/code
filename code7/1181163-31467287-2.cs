        public void LongRunningTask(String ConnectionId)
        {
            using (var svc = new Services.MyWebService.SignalRTestServiceClient())
            {
                svc.LongRunningTask(ConnectionId);
            } // end using
        } // end LongRunningTask
