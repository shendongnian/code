        public static void RemoveCollection<T>(List<T> collection)
        {
            using (db)
            {
                if (typeof(T) == typeof(BaseMovie))
                {
                    db.DeleteAll(collection);
                }
                if (typeof(T) == typeof(BaseSeries))
                {
                    db.DeleteAll(collection, recursion: true);
                }
            }
        }
