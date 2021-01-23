    public class GenericService<T>: IGenericService<T> where T : class, IDate
    {
	    readonly IGenericRepository<T> _genericRepository;
	    public IEnumerable<T> GetRecordList(DateTime date, Func<T, DateTime> dateGetter)
	    {
            var query=_genericRepository.FindBy(r => dateGetter(r) = date);
	    }
    }
