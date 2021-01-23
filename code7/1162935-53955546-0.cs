    public static class NativeConnectionExtension
    {
        public static List<T> SelectAllFrom<T>(this SQLiteConnection cnn) where T : new()
        {
            var mapping = cnn.GetMapping<T>();
            var result = cnn.Query<T>(String.Format("select * from {0};", mapping.TableName));
            return result;
        }
    }
