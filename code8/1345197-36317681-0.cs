    private void bw_DoWork(object sender, DoWorkEventArgs e)
    {
         QueryServices()
    }
    private void QueryServices()
    {
       foreach (Service Service in Globals.Services)
       {
           Service.Status = Service.Query(Service.Server, Service.Name);
       }
    }
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PopulateServicesDataGrid();
            lblLoading.Visible = false;
        }
        private void PopulateServicesDataGrid()
        {
            //Do everything else you are doing originally in this method minus the Service.Query calls.
        }
