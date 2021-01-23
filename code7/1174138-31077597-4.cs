    public interface IPerson
    {
      int AddressId { get; }
      int PerId { get; }
      int UniqueEntityId { get; }
    }
    
    public MasterPerson : IPerson {
      public int UniqueEntityId { get { return MvpId; } }
    }
    public ExceptionPerson : IPerson {
      public int UniqueEntityId  { get { return EvpId; } }
    }
