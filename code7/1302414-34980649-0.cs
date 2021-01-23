    public class Factory
    {
        public IPeople<T> GetPeople<T>()
        {
            if(typeof(T) == typeof(DomainReturn1))
                return (IPeople<T>)new Villagers();
            if(typeof(T) == typeof(DomainReturn2))
                return (IPeople<T>)new CityPeople();
            throw new Exception();
        }
    }
