    using (var svc = new Service1SoapClient())
    {
       var result = svc.GetTasks(7);
       List<ProcessQueue> Processqueue=result.ToList<ProcessQueue>();
       foreach (ProcessQueue process in Processqueue)
       {
          MessageBox.Show(process.shopId);
       }
    }
