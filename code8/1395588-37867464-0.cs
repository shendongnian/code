    modelBuilder.Types()
        .Where(t => t.IsSubclassOf(typeof(Lookup)))
        .Having(x => x.GetCustomAttributes(false).OfType<IsLookup>().FirstOrDefault())
        .Configure((config, att) => {
            config.Property("Description").HasMaxLength(att.DescriptionLength);
        });
