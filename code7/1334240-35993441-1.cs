    public class Repository<T> where T : Entity
    {
         //...
         public bool Exist(int id)
        {
          return DbSet.Exist(e=>e.Id==id);
        }
    }
