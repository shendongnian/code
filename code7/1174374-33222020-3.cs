        using (var client = new ResourceManagementClient(creds))
        {
            var v1ComputeParams = new ResourceListParameters { ResourceType = "Microsoft.ClassicCompute/virtualMachines" };
            var v2ComputeParams = new ResourceListParameters { ResourceType = "Microsoft.Compute/virtualMachines" };
            var v1ComputeResult = await client.ListRecursiveAsync(v1ComputeParams, null);
            var v2ComputeResult = await client.ListRecursiveAsync(v2ComputeParams, null);
        }
    /// <summary>
    /// Gets the list of resources, recursing until ResourceListResult.NextLink is empty. 
    /// </summary>
    /// <param name="client"></param>
    /// <param name="parameters">Optional. Query parameters. If null is passed returns all resources from all resource groups.</param>
    /// <param name="nextLink"></param>
    /// <returns></returns>
    public static async Task<IList<GenericResourceExtended>> ListRecursiveAsync(this ResourceManagementClient client, ResourceListParameters listParams, string nextLink)
    {
        var rValue = new List<GenericResourceExtended>();
        ResourceListResult computeList = null;
        if (!string.IsNullOrWhiteSpace(nextLink))
        {
            computeList = await client.Resources.ListNextAsync(nextLink);
        }
        else
        {
            computeList = await client.Resources.ListAsync(listParams);
        }
        rValue.AddRange(computeList.Resources);
        if (!string.IsNullOrWhiteSpace(computeList.NextLink))
        {
            var nextResult = await ListRecursiveAsync(client, null, computeList.NextLink);
            rValue.AddRange(nextResult);
        }
        return rValue;
    }
