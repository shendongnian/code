    var aggregations = new AggregationDictionary();
    var nested =
       new NestedAggregation("Countries") {
          Path = "MetaData.GeographicCoverage.Countries",
          Aggregations =
             new TermsAggregation("Country") {
                Field = "MetaData.GeographicCoverage.Countries.Country"
             }
           };
     aggregations["Countries"] = (AggregationContainer)nested;
