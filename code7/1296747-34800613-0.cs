    // 'clean' entity with no mongo attributes
    public class MyClass 
    {
        public Guid Id { get; set; }
    }
    
    // mappings in data layer
    BsonClassMap.RegisterClassMap<MyClass>(cm => 
    {
        cm.AutoMap();
        cm.MapIdMember(c => c.Id).SetIdGenerator(CombGuidGenerator.Instance);
    });
