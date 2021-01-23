    public object Create(object request, ISpecimenContext context)
    {
        var info = request as PropertyInfo;
        if (info != null && info.Name == "Descriptions" && info.DeclaringType == typeof(Foo))
        {
            if (info.Name == "Descriptions")
            {
                return context.Create<List<DescriptionInfo>>()
                 .GroupBy(g => g.LanguageId)
                 .Select(g => g.First())
                 .ToList();
             }
        }
        if (info != null && info.Name == "LanguageId" && info.DeclaringType == typeof(DescriptionInfo))
        {
            return LanguageIds.GetRandomElement();
        }
        return new NoSpecimen(request);
    }
