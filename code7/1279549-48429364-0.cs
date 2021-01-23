    static void Initialize()
    		{
    			Console.WriteLine("INIT");
    			try
    			{
    				// This section is only needed for the AppServer DLL model.
    				bool AppServerModel = true;
    				if (AppServerModel)
    				{
    					// Set c-tree database engine configuration file name.
    					CTSession.SetConfigurationFile("ctsrvr.cfg");
    					// Start c-tree database engine.
    					CTSession.StartDatabaseEngine();
    				}
    				// allocate objects
    				MySession = new CTSession(SESSION_TYPE.CTREE_SESSION);
    				MyTable = new CTTable(MySession);
    				MyRecord = new CTRecord(MyTable);
    			}
    			catch(CTException E)
    			{
    				Handle_Exception(E);
    			}
    			try
    			{
    				// connect to server
    				Console.WriteLine("\tLogon to server...");
    				MySession.Logon("FAIRCOMS", "", "");
    			}
    			catch(CTException E)
    			{
    				Handle_Exception(E);
    			}
    		}
    static void Display_Records()
    		{
    			bool found;
    			string custnumb;
    			string custname;
    			Console.Write("\tDisplay records...");
    			try
    			{
    				// read first record
    				found = MyRecord.First();
    				while (found)
    				{
    					custnumb = MyRecord.GetFieldAsString(0);
    					custname = MyRecord.GetFieldAsString(4);
    					Console.WriteLine("\n\t\t{0,-8}{1,-20}", custnumb, custname);
    					// read next record
    					found = MyRecord.Next();
    				}
    			}
    			catch(CTException E)
    			{
    				Handle_Exception(E);
    			}
    		}
