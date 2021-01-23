    /// <inheritdoc />
    public void PopulateFeature(
        IEnumerable<ApplicationPart> parts,
        ControllerFeature feature)
    {
        foreach (var part in parts.OfType<IApplicationPartTypeProvider>())
        {
            foreach (var type in part.Types)
            {
                if (IsController(type) && !feature.Controllers.Contains(type))
                {
                    feature.Controllers.Add(type);
                }
            }
        }
    }
