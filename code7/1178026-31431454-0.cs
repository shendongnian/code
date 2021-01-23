    var node = new Uri(elasticSearchURI);
    var connectionPool = new SniffingConnectionPool(new[] { node });
    var config = new ConnectionSettings(connectionPool)
                            .SniffOnConnectionFault(false)
                            .SniffOnStartup(false)
                            .SetTimeout(600000)
                            .DisablePing();
    _Instance = new ElasticClient(config);
    var result = _Instance.Search<LocationCoordinates>(s => s
                  .Index("universal_" + countryCode.ToLower())
                  .Type("locationcoordinates")
                  .Query(q =>
                  {
                    QueryContainer locationQuery = null;
                    locationQuery |= q.QueryString(qs=>qs.OnFields(f => f.RecordValue).Query(term).MinimumShouldMatchPercentage(100));
                    return locationQuery;
                  })
                 .Take(1)
                 .Sort(sort => sort.OnField("adminclass").Ascending())
                 .Sort(sort => sort.OnField("_score").Descending())
               );
