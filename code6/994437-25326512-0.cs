    public class Magicutil<T>
    {
        public string GetNameOfInnerT()
        {
            Type t = typeof(T);
            if (t.IsGenericType)
            {
                Type[] tArr;;
                while ((tArr = t.GetGenericArguments()).Length > 0)
                    t = tArr[0];
            }
            return t.Name;
        }
    }
