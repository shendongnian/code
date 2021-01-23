    [ComImport, Guid(MyImApp.ClassId)]
    public class MyImApp
    {
      internal const string ClassId = "<your guid>";
    }
    
    public class MyContactAndGroupsCallback : _IContactsAndGroupsCallback
    {
    
      public void OnAddCustomGroup(ContactManager _source, AsynchronousOperation _asyncOperation)
      {
      }
    
      public void OnAddDistributionGroup(ContactManager _source, AsynchronousOperation _asyncOperation)
      {
      }
    
      public void OnLookup(ContactManager _source, object _lookupResult, AsynchronousOperation _asyncOperation)
      {
      }
    
      public void OnRemoveContactFromAllGroups(ContactManager _source, AsynchronousOperation _asyncOperation)
      {
      }
    
      public void OnRemoveGroup(ContactManager _source, AsynchronousOperation _asyncOperation)
      {
      }
    
      public void OnSearch(ContactManager _source, SearchResults _searchResults, AsynchronousOperation _asyncOperation)
      {
      }
    }
    
    class Program
    {
      static bool cancelPressed = false;
      static MyContactAndGroupsCallback myContactsAndGroupsCallback = new MyContactAndGroupsCallback();
    
      static void Main(string[] args)
      {
    	 MyImApp imApp = new MyImApp();
    	 if (imApp == null) return;
    
    	 UCOfficeIntegration officeIntegration = (UCOfficeIntegration)imApp;
    	 if (officeIntegration == null) return;
    
    	 officeIntegration.OnShuttingDown += officeIntegration_OnShuttingDown;
    
    	 string officeVersion = "15.0.0.0";
    	 string authInfo = officeIntegration.GetAuthenticationInfo(officeVersion);
    	 OIFeature supportedFeatures = officeIntegration.GetSupportedFeatures(officeVersion); //skype reports: -122
    
    	 LyncClient lyncClient = (LyncClient)officeIntegration.GetInterface(officeVersion, OIInterface.oiInterfaceILyncClient);
    	 if (lyncClient == null) return;
    
    	 string uri = lyncClient.Uri;
    
    	 IAutomation automation = (IAutomation)officeIntegration.GetInterface(officeVersion, OIInterface.oiInterfaceIAutomation);
    
    	 //LyncClientCapabilityTypes capabilities = lyncClient.Capabilities; //skype: Not implemented
    	 lyncClient.OnStateChanged += lyncClient_OnStateChanged;
    
    	 ContactManager contactManager = lyncClient.ContactManager;
    	 if (contactManager == null) return;
    
    
    	 AsynchronousOperation async = contactManager.Lookup("test@test.com", myContactsAndGroupsCallback, Type.Missing);
    
    	 Contact contact = contactManager.GetContactByUri("test@test.com");
    
    	 if (contact != null)
    	 {
    		dynamic result = contact.GetContactInformation(ContactInformationType.ucPresenceInstantMessageAddresses);
    
    		ContactSettingDictionary settings = contact.Settings;
    
    		ContactSetting[] keys = settings.Keys;
    
    		if (keys != null)
    		{
    		   foreach (ContactSetting key in keys)
    		   {
    			  object value = null;
    			  settings.TryGetValue(key, out value);
    		   }
    		}
    
    	 }
    
    	 Console.CancelKeyPress += Console_CancelKeyPress;
    
    	 Console.WriteLine("Press Ctrl-C for exit");
    
    	 do
    	 {
    		System.Threading.Thread.Sleep(1000);
    
    	 } while (!cancelPressed);
    
      }
    
      static void officeIntegration_OnShuttingDown()
      {
    	 Console.WriteLine("IM Application is shutting down");
      }
    
      static void contactManager_OnSearchProviderStateChanged(ContactManager _eventSource, SearchProviderStateChangedEventData _eventData)
      {
      }
    
      static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
      {
    		cancelPressed = true;
    	 }
    
      static void lyncClient_OnStateChanged(Client _eventSource, ClientStateChangedEventData _eventData)
      {
    	 Console.WriteLine("Status changed: {0} -> {1}, {2}", _eventData.OldState, _eventData.NewState, _eventData.StatusCode);
      }
    }
