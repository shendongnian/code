    public static class Extensions
    {
        public static object GetPropertyValue(this object Obj, string PropertyName)
        {
            object Value = Obj;
            foreach (string Property in PropertyName.Split('.'))
            {
                if (Value == null)
                    break;
                Value = Value.GetType().GetProperty(Property).GetValue(Value, null);
            }
            return Value;
        }
    }
