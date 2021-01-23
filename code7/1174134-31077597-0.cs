    public interface IPerson
    {
      int AddressId { get; }
      int PerId { get; }
    }
    
    public MasterPerson : IPerson {}
    public ExceptionPerson : IPerson {}
