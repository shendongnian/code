    public class OptionService : IOptionService
    {
    	private IRepository _repository;
    	
    	public OptionService(IRepository repository)
    	{
    		_repository = repository;
    	}
    	
    	public int[] GetOptionsWithName(int id, string name)
    	{
    		_repository.Context.AsQueryable<Option>()
                               .Where(o => o.Id == id && o.Name == name)
                               .Select(o => o.Id)
                               .ToArray();
    	}
    }
