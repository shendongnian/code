	public async Task FooAsync()
	{
		AceVqbzServiceClient aceVqbzClientService = new AceVqbzServiceClient();
		aceVqbzClientService.OpenAsync();
		
		await Task.Factory.FromAsync(
						   aceVqbzTypeService.BeginSaveUserOrganizationLinking,
						   aceVqbzTypeService.EndSaveUserOrganizationLinking,
						   objUser_OrganizationDetail, TaskCreationOptions.None);
						   
		aceVqbzClientService.CloseAsync();
	}
