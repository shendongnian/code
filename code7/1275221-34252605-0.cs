    public class CloudApiParameter
    {
        public string ParameterName { get; set; }
        public string ParameterType { get; set; }
    }
    
    public class CloudApiDescription
    {
        public string Id { get; set; }
        public string RelativePath { get; set; }
        public string Document { get; set; }
        public IEnumerable<CloudApiParameter> Parameters { get; set; }
    
    }
    public IEnumerable<CloudApiDescription> Get()
    {
        var apiDescs = Configuration.Services.GetApiExplorer().ApiDescriptions;
        return apiDescs.Select(r => new CloudApiDescription()
        {
            Id = r.GetFriendlyId(),
            RelativePath = r.RelativePath,
            Document = r.Documentation,
            Parameters = (r.ParameterDescriptions.Any() ? r.ParameterDescriptions.Select(p => new CloudApiParameter()
            {
                ParameterName = p.ParameterDescriptor.ParameterName,
                ParameterType = p.ParameterDescriptor.ParameterType.ToString()
            }): null)
        });
    }
