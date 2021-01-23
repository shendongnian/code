     [ElasticProperty(OmitNorms = true, Index = FieldIndexOption.NotAnalyzed)]
            var node = new Uri("http://192.168.0.56:9200/");
            var settings = new ConnectionSettings(node, defaultIndex: "ticket");
            var client = new ElasticClient(settings);
            var createIndexResult = client.CreateIndex("ticket");
            var mapResult = client.Map<TicketElastic>(c => c.MapFromAttributes().IgnoreConflicts().Type("TicketElastic").Indices("ticket"));
