    static async Task GetRecordsFor(ForceClient client, string[] targets )
        {
            foreach (string target in targets){
                switch ( target )
                {
                    case 'leads':
                        Console.WriteLine("Get Leads");
                        var accts = new List<Lead>();
                        // more specific code for fetching leads
                        break;
    
                    case 'suppliers':
                        Console.WriteLine("Get SupplierProduct");
                        var accts = new List<SupplierProduct>();
                        // more specific code for fetching suppliers
                        break;
                }
                // Actions you want to perform on each of these.
                accts.AddRange(continuationResults.Records);
            }
        }
