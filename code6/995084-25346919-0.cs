    public class Finder
        {
            public static List<T> GetSpecificObjects<T>(List<Object> source)
            {
                return (List<T>) source.Where(item => item.GetType() == typeof (T));
            }
        }
