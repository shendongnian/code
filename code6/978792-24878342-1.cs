    //This method will return the label for the LCID of the account the IOrganizationService is using
    public static string GetOptionSetValueLabel(string entityName, string fieldName, int optionSetValue, IOrganizationService service)
    {
        var attReq = new RetrieveAttributeRequest();
        attReq.EntityLogicalName = entityName;
        attReq.LogicalName = fieldName;
        attReq.RetrieveAsIfPublished = true;
        var attResponse = (RetrieveAttributeResponse)service.Execute(attReq);
        var attMetadata = (EnumAttributeMetadata)attResponse.AttributeMetadata;
        return attMetadata.OptionSet.Options.Where(x => x.Value == optionSetValue).FirstOrDefault().Label.UserLocalizedLabel.Label;
    }
    
    //This method will return the label for the specified LCID
    public static string GetOptionSetValueLabel(string entityName, string fieldName, int optionSetValue, int lcid, IOrganizationService service)
    {
        var attReq = new RetrieveAttributeRequest();
        attReq.EntityLogicalName = entityName;
        attReq.LogicalName = fieldName;
        attReq.RetrieveAsIfPublished = true;
        var attResponse = (RetrieveAttributeResponse)service.Execute(attReq);
        var attMetadata = (EnumAttributeMetadata)attResponse.AttributeMetadata;
        return attMetadata.OptionSet.Options.Where(x => x.Value == optionSetValue).FirstOrDefault().Label.LocalizedLabels.Where(l => l.LanguageCode == lcid).FirstOrDefault().Label;
    }        
