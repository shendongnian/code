    public interface IVehicle<T> where T : Entity
    {  
        void Save(T entity);
        T Get(int id);
    }
