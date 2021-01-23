    public static class DataFetcher {
        static Dictionary<Type, Func<object>> _fetchers;
        static Dictionary<Type, Func<object>> Fetchers {
          get {
              if(_fetchers == null) _fetchers = new Dictionary<Type, Func<object>>();
              return _fetchers;
          }
        }
        static DataFetcher(){
           Fetchers[typeof(City)] = FetchCityData;
           Fetchers[typeof(State)] = FetchStateData;
        }
        public static IList<T> FetchData<T>(){
           Func<object> f;
           if(Fetchers.TryGetValue(typeof(T), out f)){
               return (IList<T>) f();
           }
           return null;
        }
    }
