    public override void OnApplyTemplate()
    {
        PushPin pin = MapExtensions.GetChildren(mapEventLocation)
            .FirstOrDefault() as Pushpin;
    }
