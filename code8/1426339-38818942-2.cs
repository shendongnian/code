    var source = new {
                    Name = EnvironmentVariable("PRIVATE_FEED_NAME"),
                    Source = EnvironmentVariable("PRIVATE_FEED_SOURCE"),
                    ApiUserName = EnvironmentVariable("PRIVATE_FEED_USERNAME"),
                    ApiKey = EnvironmentVariable("PRIVATE_FEED_PASSWORD")
                 };
    if (!NuGetHasSource(source.SourceUrl))
    {
        NuGetAddSource(
            source.Name,
            source.SourceUrl,
            new NuGetSourcesSettings {
                UserName = source.ApiUserName,
                Password = source.ApiKey
            }
        );
    }
