C#
using MongoDB.Bson;
using MongoDB.Driver;
using System;
#if TRACE
using System.Diagnostics;
using MongoDB.Driver.Core.Configuration;
#endif
...
public static ClusterBuilder ConfigureCluster(ClusterBuilder builder)
{
#if TRACE
    var traceSource = new TraceSource(nameof(Geotagging), SourceLevels.Verbose);
    builder.TraceWith(traceSource);
    builder.TraceCommandsWith(traceSource);
#endif
    return builder;
}
public MongoClient BuildMongoClient(string connection_string)
{
    var mongoUrlBuilder = new MongoUrlBuilder(connection_string);
    var settings = MongoClientSettings.FromUrl(mongoUrlBuilder.ToMongoUrl());
    settings.ClusterConfigurator = cb => ConfigureCluster(cb);
    return new MongoClient(settings);
}
