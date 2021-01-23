        public class VatInfo
    {
        public string RegistrationNumber;
        public string TaxNumber;
        public static Dictionary<string, VatInfo> GetVatList()
        {
            //TODO: Implement logic to load CSV file into a list. Dictionary key value should be Account Number        
            throw new NotImplementedException();
        }
    }
    public class UpdateVatDemo
    {
        public const int maxBatchSize = 100;
        public static void RunVatUpdate(IOrganizationService conn)
        {
            var vats = VatInfo.GetVatList();
            var pagingQuery = new QueryExpression("account");
            pagingQuery.ColumnSet = new ColumnSet("accountnumber");
            Queue<Entity> allEnts = new Queue<Entity>();
            while (true)
            {
                var results = conn.RetrieveMultiple(pagingQuery);
                if (results.Entities != null && results.Entities.Any())
                    results.Entities.ToList().ForEach(allEnts.Enqueue);
                if (!results.MoreRecords) break;
                pagingQuery.PageInfo.PageNumber++;
                pagingQuery.PageInfo.PagingCookie = results.PagingCookie;
            }
            ExecuteMultipleRequest emr = null;
            while (allEnts.Any())
            {
                if (emr == null)
                    emr = new ExecuteMultipleRequest()
                    {
                        Settings = new ExecuteMultipleSettings()
                        {
                            ContinueOnError = true,
                            ReturnResponses = true
                        },
                        Requests = new OrganizationRequestCollection()
                    };
                var ent = allEnts.Dequeue();
                if (vats.ContainsKey(ent.GetAttributeValue<string>("accountnumber")))
                {
                    var newEnt = new Entity("account", ent.Id);
                    newEnt.Attributes.Add("new_vatno", vats[ent.GetAttributeValue<string>("accountnumber")].TaxNumber);
                    newEnt.Attributes.Add("new_registrationnumber", vats[ent.GetAttributeValue<string>("accountnumber")].RegistrationNumber);
                    emr.Requests.Add(new UpdateRequest() { Target = newEnt });
                }
                if (emr.Requests.Count >= maxBatchSize)
                {
                    try
                    {
                        var emResponse = (ExecuteMultipleResponse) conn.Execute(emr);
                        foreach (
                            var responseItem in emResponse.Responses.Where(responseItem => responseItem.Fault != null))
                            DisplayFault(emr.Requests[responseItem.RequestIndex],
                                responseItem.RequestIndex, responseItem.Fault);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Exception during ExecuteMultiple: {ex.Message}");
                        throw;
                    }
                    emr = null;
                }
            }
        }
        private static void DisplayFault(OrganizationRequest organizationRequest, int count,
            OrganizationServiceFault organizationServiceFault)
        {
            Console.WriteLine(
                "A fault occurred when processing {1} request, at index {0} in the request collection with a fault message: {2}",
                count + 1,
                organizationRequest.RequestName,
                organizationServiceFault.Message);
        }
    }
