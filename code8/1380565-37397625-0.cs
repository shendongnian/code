    public static object ChangeTo(this string strValue, Type type)
    {
        if (type.IsValueType && !type.IsEnum
            && type.HasInterface(typeof(IConvertible)))
        {
            try
            {
                return Convert.ChangeType(strValue, type);
            }
            catch (Exception ex)
            {
                Tracer.Instance.WriteError(ex);
            }
        }
        return TypeSerializer.DeserializeFromString(strValue, type);
    }
