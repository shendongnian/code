    private readonly ICountryRepository _repository;
    
    public SomeServie(ICountryRepository repository){
       _repository = repository;
    }
    
    public void DoSomething(float locationId){
       _repository.GetByLocation(locationId);
    }
