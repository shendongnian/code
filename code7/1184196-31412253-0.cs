      private void BwOnDoWork(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            orderProcessing.OnOrderProgress += OrderStatus;
            orderProcessing.CreateOrders(FanGlobal.BrandItems, FanGlobal.BrandItemMasterCustomers);
        }
        private void OrderStatus(object obj, OrderProcessing.OrderProgressEventArgs e)
        {
            if (e.totalCount > 0)
               bw.ReportProgress(Convert.ToInt32(((double)e.currentCount / (double)e.totalCount) * 100),e.message);
        }
