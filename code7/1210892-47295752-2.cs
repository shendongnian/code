        using (var runtimeStatusClient = new RuntimeStatusClient())
        {
          var workerProcess = runtimeStatusClient.GetWorkerProcess(process.Id);
          // Apparently an IISExpress process can run multiple sites/applications?
          var apps = workerProcess.RegisteredUrlsInfo.Select(r => r.Split('|')).Select(u => new { SiteName = u[0], PhysicalPath = u[1], Url = u[2] });
          // If we just assume one app
          return new Uri(apps.FirstOrDefault().Url).Port;
         }
