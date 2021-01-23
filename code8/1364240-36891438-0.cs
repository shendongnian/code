       public interface IRepository<TEntity> where TEntity : EntityBase
       {
             // Other repository methods should be defined here
             // but I just define Add for the convenience of this 
             // Q&A
             void Add(TEntity entity);
       }
       
       public class Repository<TEntity> : IRepository<TEntity>
              where TEntity : EntityBase
       {
             public virtual void Add(TEntity entity)
             {
                  entity.Id = [call method here to set the whole id];
             }
       }
