    public static T NvlO<T>(object a, T b)
    {
        if (a == null)
            return b;
        else
        {
            var lSrcType = a.GetType();
            var lDestType = typeof(T);
            if (lDestType.IsValueType && lDestType.IsAssignableFrom(lSrcType))
                return (T)a;
            var lDestTC = TypeDescriptor.GetConverter(typeof(T));
            if (lDestTC.CanConvertFrom(lSrcType))
                return (T)lDestTC.ConvertFrom(a);
            else
            {
                var lSrcTC = TypeDescriptor.GetConverter(lSrcType);
                String lTmp = lSrcTC.ConvertToInvariantString(a);
                return (T)lDestTC.ConvertFromInvariantString(lTmp);
            }
        }
    }
