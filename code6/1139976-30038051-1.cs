    public PersonBL : IPersonBL
    {
      private IAuditService _auditService;
      private IPersonRepo _personRepo;
      public PersonBL(IAuditService auditService,
        IPersonRepo personRepo)
      {
        _auditService = auditService;
        _personRepo = personRepo;
      }
      public void Save(Person person)
      {
        PersonDTO personDTO = Mapper.Map<PersonDTO>(person);
        var result = _personRepo.Save(personDTO);
        if (result.Count > 0)
        {
          _auditService.Audit(result);
        }
      }
    }
