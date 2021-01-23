    var azureToken = GetAzureAuthTokenForCustomerTenant(NativeClientId, PartnerCenterUser, PartnerCenterPassword, tenantId);
    string responseContent = String.Empty;
    var roleAssignmentId = Guid.NewGuid().ToString(); 
    var correlationId = Guid.NewGuid().ToString();
    string url = string.Format("https://management.azure.com/subscriptions/{0}/providers/Microsoft.Authorization/roleAssignments/{1}?api-version=2015-07-01", subscriptionId, roleAssignmentId);
    string content = Json.Encode(CreateRoleAssignmentRequestData(subscriptionId, principalId));
    
    using (var client = new HttpClient())
    {
    	client.DefaultRequestHeaders.Clear();
    	client.DefaultRequestHeaders.Add("Accept", "application/json");
    	client.DefaultRequestHeaders.Add("Content-Type", "application/json");
    	client.DefaultRequestHeaders.Add("x-ms-correlation-id", correlationId);
        client.DefaultRequestHeaders.Add("x-ms-tracking-id", Guid.NewGuid().ToString());
        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + azureToken.AccessToken);
    	var response = await client.PutAsync(url, content);
    	while(!response.IsSuccessStatusCode) 
    	{
    		response = await client.PutAsync(url, content);
    	}
    	Console.WriteLine(response.Content.ReadAsStringAsync().Result);
    }
