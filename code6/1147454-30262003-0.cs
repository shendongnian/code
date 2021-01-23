        public static async Task AddReferencseData(ConfigurationDbContext context)
        {
            RequiredSinkTypeList.ForEach(
                sinkName =>
                {
                    var sinkType = new SinkType() { Name = sinkName };
                    context.SinkTypeCollection.Add(sinkType);
                });
            await context.SaveChangesAsync().ConfigureAwait(false);
        }
        public static async Task AddReferenceData(ConfigurationDbContext context)
        {
            foreach (var sinkName in RequiredSinkTypeList)
            {
                var sinkType = new SinkType() { Name = sinkName };
                context.SinkTypeCollection.Add(sinkType);
            }
            await context.SaveChangesAsync().ConfigureAwait(false);
        }
    
    
   
