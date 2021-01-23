     string[] filterArr = { "WdiSystemHost", "WdNisSvc", "WebClient", "Wecsvc", "WEPHOSTSVC", "wercplsupport", "WerSvc", "WiaRpc" };
        //string MachineName1 = ".";
        ServiceController[] services = ServiceController.GetServices(MachineName1);
        int k = 0;
        ServiceController[] newsers = new ServiceController[filterArr.Length];
        for (int j = 0; j < filterArr.Length; j++)
        {
            for (int i = 0; i < services.Length; i++)
            {
                if (services[i].ServiceName == filterArr[j])
                {
                    selectedservices[k++] = services[i];
                }
            }
        }
        ServiceBoundGrid.DataSource = selectedservices;
        ServiceBoundGrid.DataBind();
