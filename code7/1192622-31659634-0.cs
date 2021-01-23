    namespace AcmeFramework
    {
        namespace Entity
        {
    
            public abstract class Entity<TEntity, TDataObject, TDataObjectList, TIBusiness, TIDataAccess, TPrimaryKey>
                where   TEntity         : Entity<TEntity, TDataObject, TDataObjectList, TIBusiness, TIDataAccess, TPrimaryKey>
                where   TDataObject     : Entity<TEntity, TDataObject, TDataObjectList, TIBusiness, TIDataAccess, TPrimaryKey>.BaseDataObject
                where   TDataObjectList : Entity<TEntity, TDataObject, TDataObjectList, TIBusiness, TIDataAccess, TPrimaryKey>.BaseDataObjectList, new()
                where   TIBusiness      : Entity<TEntity, TDataObject, TDataObjectList, TIBusiness, TIDataAccess, TPrimaryKey>.IBaseBusiness
                where   TIDataAccess    : Entity<TEntity, TDataObject, TDataObjectList, TIBusiness, TIDataAccess, TPrimaryKey>.IBaseDataAccess
                where   TPrimaryKey     : IComparable<TPrimaryKey>, IEquatable<TPrimaryKey>
            {
                public class BaseDataObject
                {
                    public TPrimaryKey Id;
                }
        
                public class BaseDataObjectList : CollectionBase<TDataObject> 
                {
                    public TDataObjectList ShallowClone() { ... }
                }
        
                public interface IBaseBusiness
                {
                    TDataObjectList LoadAll();
                    TDataObject LoadById(TPrimaryKey id);
                    TDataObject LoadByIds(IEnumerable<TPrimaryKey> ids);
                    IQueryable<TDataObject> Query();
                    IQueryable<TDataObject> FindBy(Expression<Func<T, bool>> predicate);
                    void Delete(TPrimaryKey ids);
                    void Delete(IEnumerable<TPrimaryKey> ids);
                    void Save(TDataObject entity);
                    void Save(TDataObjectList entities);
                    ValidationErrors Validate(TDataObject entity);  // <- Define ValidationErrors as you see fit
                    ValidationErrors Validate(TDataObjectList entities);  // <- Define ValidationErrors as you see fit
                }
                public abstract BaseBusiness : IBaseBusiness
                {
                    private TIDataAccess dataAccess;
                    protected BaseBusiness(TIDataAccess dataAccess) { this.dataAccess = dataAccess; }
                }
                
                public interface IBaseDataAccess
                {
                    IQueryable<TDataObject> Query();
                    IQueryable<TDataObject> FindBy(Expression<Func<T, bool>> predicate);
                    void DeleteBy(Expression<Func<T, bool>> predicate);
                    void Save(TDataObjectList entities);
                }
            }
        }
        namespace Application
        {
            public interface IBaseApplicationService {}
    
            public class BaseApplicationServiceWebAPIHost<TIApplicationService> : ApiController where TIApplicationService : IBaseApplicationService
            {
                private TIApplicationService applicationService;
        
                public BaseApplicationServiceWebAPIHost(TIApplicationService applicationService) { this.applicationService = applicationService; }
            }
            public class BaseApplicationServiceWCFHost<TIApplicationService> where TIApplicationService : IBaseApplicationService
            {
                private TIApplicationService applicationService;
        
                public BaseApplicationServiceWCFHost(TIApplicationService applicationService) { this.applicationService = applicationService; }
            }
        }
