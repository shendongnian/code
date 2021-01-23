    // domain entities assembly
    public abstract class BaseEntity { }
    
    // EF entities assembly
    public abstract class BaseEFEntity : IObjectState
    // somewhere in the code
    Mapper.Map(domainEntity, efEntity);
