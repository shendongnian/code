    class Bar<T> where T : IDrink, new()
    {
        List<T> storage = new List<T>();
        public void CreateDrink()
        {
            storage.Add(new T()); 
        }
    }
