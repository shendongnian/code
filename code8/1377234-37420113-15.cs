    public class GenericService<T>: IGenericService<T> where T : class
    {
    	public Dictionary<Type, Func<object, DateTime>> _dateGetter = new Dictionary<Type, Func<object, DateTime>>()
    	{
    		{ typeof(TypeWithDate), x => ((TypeWithDate)x).Date },
    		{ typeof(TypeWithDate2), x => ((TypeWithDate2)x).Date }
    	};
	
    	readonly IGenericRepository<T> _genericRepository;
    	public IEnumerable<T> GetRecordList(DateTime date)
    	{
            var query=_genericRepository.FindBy(r => _dateGetter[typeof(T)](r) = date);
    	}
}
