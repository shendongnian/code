    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    using Xi.Client.Base.API;
    using Xi.Client.Base;
    using Xi.Contracts;
    using Xi.Contracts.Data;
    using Xi.Contracts.Constants;
    using System.ServiceModel.Description;
    using Xi.Client.CommonDialogs;
    using System.Runtime.Serialization;
    
    
    namespace ConsoleFindObjectsHDA
    {
        public class DotNetSupport
        {
            IXiEndpointDiscovery iEndpointDiscovery;
            IXiContext iContext;
            IXiEndpointBase readEndpoint;
    
            ServiceEndpoint RMSvcEndpt;
    
            //the list of items the user is trying to read
            IXiDataJournalList iDataJournalList;
    
            public void GetSomeData()
            {
                //get a connection to an OPC.NET server
                if (Connect())
                {
                    //we have to have a list to add a tag to and hold returned datasets
                    if (CreateJournalList())
                    {
                        //now use the list to add items and read their attributes - only "good" ones will be left on the list
                        ListAllHDAItemsOnScan();
    
                        if (iDataJournalList.Count() > 0)
                        {
                            //at this point we <should> have a DataJournalList containing only the HDA items on scan
                            //we can use the normal data read methods to get history for the items if we wish
    
                            //  <do some history thing here>
                        }
                        else
                        {
                            Console.WriteLine("\nThere were no points on-scan in the historian");
                        }
    
                        Console.WriteLine("\nPress <return> to exit program");
                        Console.ReadLine();
                    }
    
                    ////clean up if we have open connections/contexts
                    Cleanup();
                }
    
            }
    
            //we will use FindObjects to browse all the leaves in the HDA server, then add them one-by-one to a datalist
            //when we query their on-scan property and it is true we leave them on the list
            //...if not, we remove them (giving us a list of the good HDA points)
            void ListAllHDAItemsOnScan()
            {
                FindCriteria criteria = GetLeafCriteria(); 
                IEnumerable<ObjectAttributes> enumerableObject;
    
                try
                {
                    //ask the server for a list of leaves...up to 50 max returned in this call
                    enumerableObject = iContext.FindObjects(criteria, 50);
    
                    //for each string itemID: add it to the list, read the attribute, and remove it from the list if not on-scan
                    foreach (ObjectAttributes oa in enumerableObject)
                    {
                        //we do not have to commit this because we have indicated the operation is NOT prep-only
                        Console.WriteLine("Adding OPCHDA item {0}.", oa.InstanceId.LocalId);
                        IXiHistoricalDataObject ixObject = iDataJournalList.AddNewDataObjectToDataJournalList(oa.InstanceId, false);   
    
                        //we are getting the CURRENT (from NOW -to- NOW) item status
                        FilterCriterion fc1 = GetFilterCriteriaDateTime(DateTime.Now); 
    
                        //tell the server what property (attribute) we want to read
                        List<TypeId> lstp = new List<TypeId>();
                        TypeId typeit = new TypeId("", "", DVServerAttributes.DELTAV_DVCH_ON_SCAN.ToString());
                        lstp.Add(typeit);
    
                        //read the property from the server
                        iDataJournalList.ReadJournalDataProperties(fc1, fc1, ixObject, lstp);
    
                        //find the current item and check it for "on-scan"
                        if (ixObject != null)
                        {
                            if (ixObject.PropertyValues.First().PropertyValues.UintValues.First() == 1)
                            {
                                Console.WriteLine("OPCHDA item {0} is on-scan.\n", oa.InstanceId.LocalId);
                            }
                            else
                            {
                                if (ixObject.PrepForRemove())
                                {
                                    Console.WriteLine("OPCHDA item {0} is not on-scan. Removing item.\n", oa.InstanceId.LocalId);
                                    iDataJournalList.CommitRemoveableElements();
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception in FindObjects(). The exception is:{0}\n", ex.Message);
                }
    
            }
    
    
            //create a filtercriterion for a specific date time - this is an EQUAL (not > or <) comparison operator
            public FilterCriterion GetFilterCriteriaDateTime(DateTime dtChosenTime)
            {
                //simple timestamp filter which is used by the read call
                FilterCriterion filterCriterion = null;
    
                // this is a timestamp
                string filterOperand = FilterOperandNames.Timestamp;
    
                //make the given time with UTC/Local set to local time just to be sure
                DateTime dtTmp1 = DateTime.SpecifyKind(dtChosenTime, DateTimeKind.Local);
                object comparisonValue = dtTmp1;
    
                //timestamp equal to this one 
                uint oper = FilterOperator.Equal;
    
                //create the filter
                filterCriterion = new FilterCriterion()
                {
                    OperandName = filterOperand,
                    Operator = oper,
                    ComparisonValue = comparisonValue,
                };
    
                return filterCriterion;
            }
    
            //create a filtercriterion for leaves (OPCHDA items)
            public FilterCriterion GetLeafFilterCriterion()
            {
                //simple filter for leaves 
                FilterCriterion filterCriterion = null;
    
                // what this criterion applies to
                string filterOperand = FilterOperandNames.BranchOrLeaf;
    
                //Must equal "LEAF" to match
                uint oper = FilterOperator.Equal;
    
                //create the filter
                filterCriterion = new FilterCriterion()
                {
                    OperandName = filterOperand,
                    Operator = oper,
                    ComparisonValue = "LEAF",
                };
    
                return filterCriterion;
            }
    
            //set up the FindCriteria search of the server  
            public FindCriteria GetLeafCriteria()
            {
                FindCriteria findCriteria = null;
                findCriteria = new FindCriteria();
    
                //our browse starts at the root - NULL means "continue browsing from where you are"
                findCriteria.StartingPath = new ObjectPath("//", "HDA");
    
                //a list of OR-ed filter criteria (we have only one)
                ORedFilters orthefilters = new ORedFilters();
    
                //the FilterCriteria list (there is only one criterion)
                orthefilters.FilterCriteria = new List<FilterCriterion>();
                orthefilters.FilterCriteria.Add(GetLeafFilterCriterion());  //we want leaves
    
                //add our OR-ed filter to the filterset filters list (whew!)
                findCriteria.FilterSet = new FilterSet();
                findCriteria.FilterSet.Filters = new List<ORedFilters>();
                findCriteria.FilterSet.Filters.Add(orthefilters);
    
                return findCriteria;
            }
    
    
            //connect to the OPC.NET server and get a read endpoint
            public bool Connect()
            {
                //set this to point to your OPC.Net server
                string serverUrl = "http://localhost:58080/XiServices/ServerDiscovery";
    
                bool bReturnVal = false;
    
                try
                {
                    Console.WriteLine("Getting Endpoint Discovery from server:\n{0}\n", serverUrl);
    
                    //This class is used to locate a server and obtain its list of ServiceEndpoints.
                    iEndpointDiscovery = new XiEndpointDiscovery(serverUrl) as IXiEndpointDiscovery;
    
                    //we have the server...now check for endpoints
                    //there should always be TCP endpoints for a DeltaV OPC.NET server so we do not search HTTP and Named Pipes to find one
                    //and we do not consider choosing the fastest option between the three (TCP/HTTP/NamedPipes). We just use the TCP/IP one.
    
                    // GetServiceEndpointsByBinding searches the list of endpoints on the XiEndpointDiscovery connection with the specified contractType and binding type.
                    // We use the ResourceManagement endpoint to find the the other open endpoints on the server (some might be disabled)
                    IEnumerable<ServiceEndpoint> resourceEndpoints = iEndpointDiscovery.GetServiceEndpointsByBinding(typeof(IResourceManagement).Name, typeof(System.ServiceModel.NetTcpBinding));
    
                    //use the first (probably only) resource endpoint for TCP/IP to open a context between client and server
                    if ((resourceEndpoints != null) && (resourceEndpoints.Count() > 0))
                    {
    
                        var serviceEndpoints = resourceEndpoints as IList<ServiceEndpoint> ?? resourceEndpoints.ToList();
    
    
                        //pick the first RM endpoint we found
                        RMSvcEndpt = ((IList<ServiceEndpoint>)serviceEndpoints).First();
    
                        //Open the Context using the RM endpoint and some other values including timeout, what we want to read (HDA), and the GUID for this context
                        Console.WriteLine("Opening Client Context with Initiate\n");
                        iContext = XiContext.Initiate(RMSvcEndpt,
                                                            iEndpointDiscovery.ServerEntry,
                                                            300000,
                                                            (uint)ContextOptions.EnableJournalDataAccess,   //HDA
                                                            (uint)System.Threading.Thread.CurrentThread.CurrentCulture.LCID,
                                                            Guid.NewGuid().ToString());
                        
                        if (iContext != null)
                        {
    
                            //find a read endpoint using the XiEndpointDiscovery connection
                            IEnumerable<ServiceEndpoint> readseps = iEndpointDiscovery.GetServiceEndpointsByBinding(typeof(IRead).Name, RMSvcEndpt.Binding.GetType());
    
                            //if we found at least one read endpoint, connect the context to it
                            readEndpoint = null;
                            if (readseps != null)
                            {
                                Console.WriteLine("Adding Read endpoint to Context\n");
                                ServiceEndpoint sep = readseps.ElementAt<ServiceEndpoint>(0);
                                readEndpoint = iContext.OpenEndpoint(sep, 30000, new TimeSpan(5000));
    
                                if (readEndpoint != null)
                                {
                                    bReturnVal = true;        //everything went OK
                                }
                                else
                                {
                                    Console.WriteLine("Unable to add Read endpoint to Context\n");
                                    bReturnVal = false;        //failed
                                }
    
                            }
                        }
                        else
                        {
                            Console.WriteLine("Unable to open Client Context\n");
                            bReturnVal = false;
                        }
                    }
                   
                }
                catch (Exception)
                {
                    bReturnVal = false;
                }
    
                return (bReturnVal);
            }
    
    
            public bool CreateJournalList()
            {
                bool retval = false;
    
                try
                {
                    //create a new list of HDA objects for this read
                    //                                             update  buffer  
                    //                                             rate    rate   filterset(not used here)
                    iDataJournalList = iContext.NewDataJournalList(1000,   1000,  null);
    
                    if (iDataJournalList != null)
                    {
                        //we need to add the list to a read endpoint to give it data access
                        iDataJournalList.AddListToEndpoint(readEndpoint);
                        
                        //enable the list so we can connect the items we add to it and read data
                        iDataJournalList.EnableListUpdating(true);
    
                        retval = true;
                    }
                }
                catch (Exception)
                {
                    retval = false;
                }
    
                return retval;
            }
    
    
            public void Cleanup()
            {
                if (iContext != null)
                {
                    iContext.Dispose();
                }
    
            }
    
        } //class DotNetSupport
    }
    namespace ConsoleFindObjectsHDA
    {
        public class DVServerAttributes
        {
            //some DeltaV-specific OPCHDA attributes
            public static uint DELTAV_DESC               = 2147483650;
            public static uint DELTAV_ENG_UNITS          = 2147483651;
            public static uint DELTAV_EU100              = 2147483666;
            public static uint DELTAV_EU0                = 2147483667;
            public static uint DELTAV_DVCH_LAST_DOWNLOAD = 2147483682;
            public static uint DELTAV_DVCH_ON_SCAN       = 2147483683;
            public static uint DELTAV_NAMED_SET          = 2147483698;
        }
    }
