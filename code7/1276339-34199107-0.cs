    public class NegatingTypeConverter : IBindingTypeConverter
    {
        public int GetAffinityForObjects(Type fromType, Type toType)
        {
            if (fromType == typeof (bool) && toType == typeof (bool)) return 10;
            return 0;
        }
        public bool TryConvert(object from, Type toType, object conversionHint, out object result)
        {
            result = null;
            if (from is bool && toType == typeof (bool))
            {
                result = !(bool) from;
                return true;
            }
            return false;
        }
    }
