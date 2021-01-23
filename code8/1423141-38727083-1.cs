    foreach (SectionGenerator<TArgs> generator in generators)
    {
        if (SectionContainedWithin(args, generator.RegisterSection))
        {
            await generator.Generate(args);
        }
    }
