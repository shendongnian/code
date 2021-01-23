	using Microsoft.Xrm.Sdk;
	using Microsoft.Xrm.Sdk.Messages;
	using Microsoft.Xrm.Sdk.Metadata;
	using Microsoft.Xrm.Tooling.Connector;
	using System.Collections.Generic;
	using System.Linq;
	public void Run(IOrganizationService svc)
	{
		var all = allAttributes(svc, "account");
		var accountNum = all.Where(a => a.LogicalName == "accountnumber").FirstOrDefault();
		var isRequired = accountNum.RequiredLevel.Value == AttributeRequiredLevel.SystemRequired;
		var type = accountNum.AttributeType;
		//to get max length, cast AttributeMetadata instance to appropriate type
		var myStringAttribute = accountNum as StringAttributeMetadata;
		var maxLength = myStringAttribute.MaxLength;
	}
	//Retrieve all attributes of an entity
	private List<AttributeMetadata> allAttributes(IOrganizationService svc, string entity)
	{
		var req = new RetrieveEntityRequest();
		req.EntityFilters = EntityFilters.Attributes;
		req.LogicalName = entity.ToLower();
		var response = (RetrieveEntityResponse)svc.Execute(req);
		return response.EntityMetadata.Attributes.ToList();
	}
