    public async Task GetTileDataAsync()
    {
      ...
      var res = await client.ViewDetailsAsync();
      CurrentName = res.NameView;
      CurrentDescription = res.DescriptionView;
      CurrentType = res.TypeView;
    }
