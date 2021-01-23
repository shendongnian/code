	public void ConfigureServices(IServiceCollection services)  
	  {
		  services.AddMvc()
					  .AddJsonOptions(options =>
					  {
						  options.SerializerSettings.ContractResolver =
							  new CamelCasePropertyNamesContractResolver();
					  });
	  }
