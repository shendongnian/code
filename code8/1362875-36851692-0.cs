    public interface IFactory
    {
        ICar<TEntity> CreateCar<TEntity>();
        IBoat<TEntity> CreateBoat<TEntity>();
        void Release(object component); // left type as object so it can release either a boat or a car
    }
