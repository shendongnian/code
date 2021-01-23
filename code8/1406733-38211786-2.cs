    public static Repository<IEntity> GetRepository()
    {
        CustomerRepository repository1 = unitOfWork.CustomerRepository;
        Repository<IEntity> repository2 = repository1;
        return repository2;
    }
