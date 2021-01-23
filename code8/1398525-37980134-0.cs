    public class CastJavaObject
    {
        public static T Cast<T>(Java.Lang.Object obj) where T : recBatch
        {
            var propInfo = obj.GetType().GetProperty("Instance");
            return propInfo == null ? null : propInfo.GetValue(obj, null) as T;
        }
    }
