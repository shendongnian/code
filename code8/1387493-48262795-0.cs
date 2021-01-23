    public static string GetApplicationPoolNames()
    {
    	// Get Server Credentials and Server Name from config file
    	string UName = ConfigurationManager.AppSettings["User"];
    	string Pwd = ConfigurationManager.AppSettings["Pass"];
    	string ServerName = DT.Rows[i]["ServerName"].ToString().Trim(); //Server Names from db
    	DirectoryEntries appPools = null;
    	try
    	{
    		appPools = new DirectoryEntry("IIS://" + ServerName + "/W3SVC/AppPools", UName, Pwd).Children;
    	}
    	catch(Exception ex)
    	{
    		log.ErrorFormat("serviceLogic -> InsertStatus() -> IIS Pool App Region -> DirectoryEntries -> Error: ", ex.Message.ToString());
    	}
    
    	log.Info("IIS App Pool Section Started for " + System.Environment.MachineName.ToString());
    
    	try
    	{
    		foreach (DirectoryEntry appPool in appPools)
    		{
    			log.Info("App Pool : " + appPool.Name.ToString());
    			int intStatus = 0;
    			string status = "";
    			try
    			{
    				if (appPool.Name.ToString().ToLower().Trim() == DT.Rows[i]["AppPoolSrvName"].ToString().ToLower().Trim())
    				{
    					log.Info("Process Started for App Pool : " + appPool.Name.ToString());
    
    					intStatus = (int)appPool.InvokeGet("AppPoolState");
    					switch (intStatus)
    					{
    						case 2:
    							status = "Running";
    							break;
    						case 4:
    							status = "Stopped";
    							break;
    						default:
    							status = "Unknown";
    							break;
    					}
    
    					//Store status info to db or file Logic goes here..
    					
    					//Start App pool, If any application pool status is not Running.
    					if (status != "Running")
    						appPool.Invoke("Start", null);
    
    					log.Info("Process Completed for App Pool : " + appPool.Name.ToString());
    				}
    			}
    			catch (Exception ex)
    			{
    				log.ErrorFormat("serviceLogic -> InsertStatus() -> IIS Pool App Region -> Error: ", ex.Message);
    			}
    		}
    	}
    	catch (Exception ex)
    	{
    		log.ErrorFormat("serviceLogic -> InsertStatus() -> IIS Pool App Region -> DirectoryEntries -> Error: ", ex.Message);
    	}
    }
