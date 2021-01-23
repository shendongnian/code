    public class ModuleDto
    {
        public int id { get; set; }
        public string moduleName { get; set; }
        public IEnumerable<PolicyDto> policies { get; set; }
    }
    public class PolicyDto
    {
        public int id { get; set; }
        public int subscriberId { get; set; }
        public SubscriberDto subscriber { get; set; }
    }
    public class SubscriberDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public int subscriptionId { get; set; }
    }    
    ...other code here...
    return db.modules
        .Where(m => m.id == id)
        .Include (m => m.policies.Select(p => p.subscriber))
        .Select(m => new ModuleDto {
            m.id,
            m.moduleName,
            policies = m.policies.Select(p => new PolicyDto
            {
                p.id,
                p.subscriberId,
                subscriber = new SubsciberDto
                {
                    p.subscriber.id,
                    p.subscriber.name,
                    p.subscriber.subscriptionId,
                }
            }
        });
