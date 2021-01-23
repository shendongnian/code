    	private const string swaggerApikey = "swagger-apiKey";
		private void Configuration([NotNull] IAppBuilder app)
		{
			var config = new HttpConfiguration();
			config.MessageHandlers.Add(new SwaggerMessageHandler());
			config
				.EnableSwagger(c =>
				{
					c.ApiKey(swaggerApikey)
						.Description(swaggerApikey)
						.Name(swaggerApikey)
						.In("header");
				})
				.EnableSwaggerUi(c =>
				{
					c.EnableApiKeySupport(swaggerApikey, "header");
				});
			app.UseWebApi(config);
		}
		internal class SwaggerMessageHandler : DelegatingHandler
		{
			protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
			{
				if (request.RequestUri.LocalPath.Equals("/swagger/docs/v1"))
				{
					var apikey = request.Headers.FirstOrDefault(x => x.Key.Equals(swaggerApikey)).Value?.FirstOrDefault();
					if (!"secretApiKey".Equals(apikey))
						return Task.FromResult(new HttpResponseMessage(HttpStatusCode.Forbidden));
				}
				return base.SendAsync(request, cancellationToken);
			}
		}
