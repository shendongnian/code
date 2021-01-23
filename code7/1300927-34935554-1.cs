    app.Use( async ( context, next ) =>
    {
        var pathAndQuery = context.Request.GetUri().PathAndQuery;
        const string apiEndpoint = "/api/someapi/";
        if ( !pathAndQuery.StartsWith( apiEndpoint ) )
            //continues through the rest of the pipeline
            await next();
        else
        {
            using ( var httpClient = new HttpClient() )
            {
                var response = await httpClient.GetAsync( "http://some-api.com/api/v2/" + pathAndQuery.Replace( apiEndpoint, "" ) );
                var result = await response.Content.ReadAsStringAsync();
                context.Response.StatusCode = (int)response.StatusCode;
                await context.Response.WriteAsync( result );
            }
        }
    } );
