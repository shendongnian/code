    public interface IFactory
    {
        ICar<TEntity> CreateCar<TEntity>(ConnectionDetails connectionDetails);
        IBoat<TEntity> CreateBoat<TEntity>(ConnectionDetails connectionDetails);
        void Release(object component); // left type as object so it can release either a boat or a car
    }
