    public interface IEntity
    {
      int ID { get; }
    }
    public class Superset<T> where T : IEntity
    {
      public Dictionary<Type, Dictionary<int, T>> m_Map = 
        new Dictionary<Type, Dictionary<int, T>>();
      private Dictionary<int, T> GetDictionary(Type t)
      {
        Dictionary<int, T> result = null;
        if (!m_Map.TryGetValue(t, out result))
        {
          result = new Dictionary<int, T>();
          m_Map.Add(t, result);
        }
        return result;
      }
      public void Add<K>(K item) where K : T
      {
        GetDictionary(typeof(K)).Add(item.ID, item);
      }
      public bool Remove<K>(K item) where K : T
      {
        return GetDictionary(typeof(K)).Remove(item.ID);
      }
    }
