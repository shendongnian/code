    protected override sealed void LoadResources()
    {
        var skinResolver = PreLoadResources();
        try
        {
            var skinBamlStreams = skinResolver.GetSkinBamlStreams(_fullName, _resourceName);
            foreach (var resourceStream in skinBamlStreams)
            {
                var skinResource = BamlHelper.LoadBaml<ResourceDictionary>(resourceStream);
                if (skinResource != null)
                {
                    Resources.Add(skinResource);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            PostLoadResources();
        }
    }
