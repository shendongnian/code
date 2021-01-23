    TileProviders providers = axMap1.Tiles.Providers; 
        int providerId = (int)tkTileProvider.ProviderCustom + 1;
        //providers.Add(providerId, "Custom TMS provider", "http://{switch:a,b,c}.tile.openstreetmap.org/{zoom}/{x}/{y}.png", tkTileProjection.SphericalMercator, 1, 18);
        if (providers.Add(providerId, "MyProvider", "http://localhost/maps/{zoom}/{x}/{y}.png", tkTileProjection.SphericalMercator, 1, 18))
        {
            axMap1.Projection = tkMapProjection.PROJECTION_GOOGLE_MERCATOR;
            axMap1.Tiles.ProviderId = providerId;
            axMap1.Tiles.ProviderId = providerId;
            axMap1.ZoomToTileLevel(1);
        }
        else
        {
          //ERROR message box
        }
