       public ActionResult ProcessRec()
       {
            HostingEnvironment.QueueBackgroundWorkItem(waitTimer);
            return RedirectToAction("Index", "Home");
       }
    
       public void waitTimer(CancellationToken token)
       {
            Thread.Sleep(10000);
       }
       //You also could do
       public Task waitTimer2(CancellationToken token)
       {
            await Task.Delay(10000);
       }
