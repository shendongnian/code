	public async Task<EntityResourceDescriptor> GetEntityDescriptor(string entityType)
	{
		var req = new RestRequest("/qcbin/rest/domains/{domain}/projects/{project}/customization/entities/{entityType}");
		AddDomainAndProject(req);
		req.AddParameter("entityType", entityType, ParameterType.UrlSegment);
		var res = await client.ExecuteTaskAsync<EntityResourceDescriptor>(req);
		if (res.ResponseStatus == ResponseStatus.Error)
		{
			throw new Exception("rethrowing", res.ErrorException);
		}
		else
		{
			return res.Data;
		}
	}
