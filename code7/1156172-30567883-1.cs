    public CompanyDetails[] GetDetails(string json)
    {
        // this adds automatic camel casing conversions
        JsonConvert.DefaultSettings = () => new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
    
        return JsonConvert.DeserializeObject<CompanyDetails[]>(json);
    }
