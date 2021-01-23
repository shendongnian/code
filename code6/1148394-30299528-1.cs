    public interface IEntityManagerWrapper {
        T GetEntityManager<T>(EntityManager.EntityManagerInstanceType instanceType) where T : EntityManager;
    }
    
    public class EntityManagerWrapper : IEntityManagerWrapper {
        public T GetEntityManager<T>(EntityManager.EntityManagerInstanceType instanceType) where T : EntityManager {
            return EntityManager.GetEntityManager<T>(instanceType);
        }
    }
