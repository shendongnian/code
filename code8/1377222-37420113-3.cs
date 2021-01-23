    public class GenericService<T>: IGenericService<T> where T : class, IDate
    {
	    public Func<T, DateTime> DateGetter { get; set; }
	
	    readonly IGenericRepository<T> _genericRepository;
	    public IEnumerable<T> GetRecordList(DateTime date)
	    {
            var query=_genericRepository.FindBy(r => DateGetter(r) = date);
	    }
    }
