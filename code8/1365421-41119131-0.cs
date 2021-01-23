    public class TrackedPropertiesBuilder : ITrackedPropertiesBuilder
    {
        private ImmutableHashSet<string>.Builder trackedPropertiesBuilder;
        public TrackedPropertiesBuilder()
        {
            this.trackedPropertiesBuilder = ImmutableHashSet.CreateBuilder<string>();
        }
        public ITrackedPropertiesBuilder Add(string propertyName)
        {
            this.trackedPropertiesBuilder.Add(propertyName);
            return this;
        }
        public IReadOnlyCollection<string> Build() => this.trackedPropertiesBuilder.ToImmutable();
    }
