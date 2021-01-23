        using System.ServiceProcess;        
        ...
        public ActionResult Update()
        {
            int updateCommandId = 1; //example
            ServiceController sc = new ServiceController("windowsServiceName");
            sc.ExecuteCommand(updateCommandId);
     
        }
