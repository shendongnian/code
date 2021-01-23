    public static class Extensions
    {
        public  static bool DeserializeJson<T>(this String str, out T item)
        {
            item = default(T);
            try
            {
                item = new JavaScriptSerializer().Deserialize<T>(str);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
