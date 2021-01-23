        CancellationTokenSource tokenSource2 = new CancellationTokenSource();
        CancellationToken ct;
        public MainWindowViewModel()
        {      
      
            ct = tokenSource2.Token;
            Task.Factory.StartNew(PopulateDataGrid, ct);
        }
        /// <summary>
        /// 
        /// </summary>
        private void PopulateDataGrid()
        {           
            for (int i = 1; i < 10000; i++)
            {
                if (!ct.IsCancellationRequested)
                {
                  
                     ///Populate Your Control here                   
                }
                else
                {
                    break;
                }
            }
        }
        public void OnCancelCLick()
        {
            tokenSource2.Cancel();
        }
    }
