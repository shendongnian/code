    public class Event
    {
        public virtual int EventId { get; set; }
        public virtual string Name { get; set; }
        public virtual IEventNode EventNode { get; set; }
    }
    public interface IEventNode { }
    // example using FluentNHibernate Mapping
    public class EventMap : ClassMap<Event>
    {
        public EventMap()
        {
            Id(x => x.EventId);
            Map(x => x.Name);
            var any = ReferencesAny(x => x.EventNode)
                .EntityIdentifierColumn("eventNode_id")
                .EntityTypeColumn("EventType")
                .IdentityType<int>()
                .MetaType<int>();
            foreach (var eventNodeType in   typeof(Event).Assembly.GetExportedTypes().Where(typeof(IEventNode).IsAssignableFrom))
            {
                if (!eventNodeType.IsInterface && !eventNodeType.IsAbstract)
                    any.AddMetaValue(eventNodeType, eventNodeType.Name);
            }
        }
    }
