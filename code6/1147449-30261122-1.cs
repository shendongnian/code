    internal static async Task AddReferencseData(ConfigurationDbContext context)
    {
        await RequiredSinkTypeList.ForEachAsync(async sinkName =>
        {
            var sinkType = new SinkType() { Name = sinkName };
            context.SinkTypeCollection.Add(sinkType);
            await context.SaveChangesAsync().ConfigureAwait(false);
        });
    }
