    Uri node        = new Uri(ES_ADDRESS);
    var settings    = new ConnectionSettings(node);
    settings.DisableDirectStreaming();//Check json
    var client      = new ElasticClient(settings);
    //Analyzers:
    CustomAnalyzer shingles = new CustomAnalyzer
    {
      Tokenizer = "standard",
      Filter = new List<string>()
      {
        "standard", "lowercase", "shingle"
      }
    };
    //Settings for index:
    var mapperTemplate = new CreateIndexDescriptor(string.Format("customers"))
      .Settings(s => s
        .Analysis(a => a
          .Analyzers(an => an
            .UserDefined("analyzer_shingles", shingles)
          )
        )
      );
    var customer = mapperTemplate.Mappings(ms => ms
      .Map<customers>(m => m
        .AllField(a => a.Analyzer("analyzer_shingles"))
        .AutoMap()
      )
    );
    
    //Create index:
    var response = client.CreateIndex(customer);
