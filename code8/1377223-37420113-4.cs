    public class GenericService<T>: IGenericService<T> where T : class, IDate
    {
	    Func<T, DateTime> _dateGetter;
	    public GenericService(..., Func<T, DateTime> dateGetter)
	    {
		    _dateGetter = dateGetter
		    ...
	    }
	
	    readonly IGenericRepository<T> _genericRepository;
	    public IEnumerable<T> GetRecordList(DateTime date)
	    {
            var query=_genericRepository.FindBy(r => _dateGetter(r) = date);
	    }
    }
