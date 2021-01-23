    class GenericService<T>: IGenericService<T> where T : class : IDate
    {
      readonly IGenericRepository<T> _genericRepository;
      public IEnumerable<T> GetRecordList(DateTime date)
      {
             var query=_genericRepository.FindBy(r=>r.Date=date);
    }
     public interface IDate
    {
        DateTime Date{set;get;}
    }
    public class Entity : IDate
    {
        DateTime Date { set; get; }
    }
