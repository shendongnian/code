	public async Task FooAsync()
	{
		AceVqbzServiceClient aceVqbzClientService = new AceVqbzServiceClient();
		aceVqbzClientService.OpenAsync();
		IAceVqbzService aceVqbzTypeService = aceVqbzClientService as IAceVqbzService;
		
		await Task.Factory.FromAsync(
						   aceVqbzTypeService.BeginSaveUserOrganizationLinking,
						   aceVqbzTypeService.EndSaveUserOrganizationLinking,
						   objUser_OrganizationDetail, TaskCreationOptions.None);
						   
		aceVqbzClientService.CloseAsync();
	}
