    var service = new OrganizationService(conn);
    var whoReq = new WhoAmIRequest();
    var whoResp = (WhoAmIResponse)service.Execute(whoReq);
    var cleanClaimsFromDB = db.CleanSupplierClaims.Select(x => x).ToList();
    var service = organizationService as OrganizationService;
    if (service != null)
     {
        var serviceProxy = service.InnerService as OrganizationServiceProxy;
        if (serviceProxy == null) throw new InvalidCastException("invalid cast");
        serviceProxy.CallerId = whoResp.UserId; //The user GUID you want to pass as the caller         
     }
    var cleanClaimsFromDB = db.CleanSupplierClaims.Select(x => x).ToList();
    foreach (var claim in cleanClaimsFromDB)
    {
        var CRMSupplierClaimsData = new new_supplierclaimsupdate()
        {
            new_Action = claim.Action.Trim(),
            new_InvoiceNumebr = claim.Line_Number.Trim(),
            new_TotalClaim = Convert.ToDecimal(claim.Total_Claim).ToString(),
            new_Currency = claim.Currency.Trim(),
            new_Supplier = claim.ClaimReference.Trim(),
            OwnerId = new EntityReference(SystemUser.EntityLogicalName, userid),
        };
        service.Create(CRMSupplierClaimsData);
    }
