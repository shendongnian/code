    [TestMethod, TestCategory("MongoService")]
    public void ChartServiceClient_CRD_ExecutesSuccessfully()
    {
        SetupHost();
        BsonClassMap.RegisterClassMap<ChartDefinitionBase>(cm =>
        {
            cm.AutoMap();
            cm.MapIdMember(c => c.Id).SetIdGenerator(StringObjectIdGenerator.Instance);
        });
        using (var client = new ChartServiceClient())
        {
            client.Create(_dto); 
            ChartDefinitionBase dto = null;
            while (dto == null)
            {
                var dtos = client.GetAllCharts(); 
                dto = dtos.SingleOrDefault(d => d.Id == _dto.Id);
            }
            client.Delete(_dto);
            while (dto != null)
            {
                var dtos = client.GetAllCharts();
                dto = dtos.SingleOrDefault(d => d.Id == _dto.Id);
            }
        }
    }
