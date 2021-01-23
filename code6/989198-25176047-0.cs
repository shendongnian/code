    // BrowseAndReadValues: Console application that recursively browses and displays the nodes in the OPC address space, and 
    // attempts to read and display values of all OPC items it finds.
    
    using System.Diagnostics;
    using JetBrains.Annotations;
    using OpcLabs.EasyOpc;
    using OpcLabs.EasyOpc.DataAccess;
    using System;
    
    namespace BrowseAndReadValues
    {
        class Program
        {
            const string ServerClass = "OPCLabs.KitServer.2";
    
            [NotNull]
            static readonly EasyDAClient Client = new EasyDAClient();
    
            static void BrowseAndReadFromNode([NotNull] string parentItemId)
            {
                // Obtain all node elements under parentItemId
                var nodeFilter = new DANodeFilter();    // no filtering whatsoever
                DANodeElementCollection nodeElementCollection = Client.BrowseNodes("", ServerClass, parentItemId, nodeFilter);
                // Remark: that BrowseNodes(...) may also throw OpcException; a production code should contain handling for it, here 
                // omitted for brevity.
    
                foreach (DANodeElement nodeElement in nodeElementCollection)
                {
                    Debug.Assert(nodeElement != null);
    
                    // If the node is a leaf, it might be possible to read from it
                    if (nodeElement.IsLeaf)
                    {
                        // Determine what the display - either the value read, or exception message in case of failure.
                        string display;
                        try
                        {
                            object value = Client.ReadItemValue("", ServerClass, nodeElement);
                            display = String.Format("{0}", value);
                        }
                        catch (OpcException exception)
                        {
                            display = String.Format("** {0} **", exception.GetBaseException().Message);
                        }
    
                        Console.WriteLine("{0} -> {1}", nodeElement.ItemId, display);
                    }
                    // If the node is not a leaf, just display its itemId
                    else
                        Console.WriteLine("{0}", nodeElement.ItemId);
    
                    // If the node is a branch, browse recursively into it.
                    if (nodeElement.IsBranch &&
                        (nodeElement.ItemId != "SimulateEvents") /* this branch is too big for the purpose of this example */)
                        BrowseAndReadFromNode(nodeElement);
                }
            }
    
            static void Main()
            {
                Console.WriteLine("Browsing and reading values...");
                // Set timeout to only wait 1 second - default would be 1 minute to wait for good quality that may never come.
                Client.InstanceParameters.Timeouts.ReadItem = 1000;
    
                // Do the actual browsing and reading, starting from root of OPC address space (denoted by empty string for itemId)
                BrowseAndReadFromNode("");
    
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }
    }
