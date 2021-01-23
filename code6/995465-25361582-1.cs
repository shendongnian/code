    public static List<EMPRESA> ListaEmpresas
    public static Task<List<T>> GenerateAsyncListFromRepository(IGenericRepositoryBlockable<T> repository)
    {
        return repository.GetAllActive().ToListAsync();
    }
