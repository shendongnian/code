        public static void insertTable(String json, String table)
        {
            using (localDBService db = new localDBService())
            {
                var tableType = Type.GetType("eStartService." + table);
                var list = DeserializeList(json, tableType);
                try
                {
                    var set = db.Set(tableType);
                    foreach (var item in list)
                        set.Add(item);
                    db.SaveChanges();
                    log.Info("Scritto sul database dal metodo InsertTable");
                }
                catch (Exception ex)
                {
                    log.Info("ERRORE DI SCRITTURA SUL DATABASE METODO : insertTable");
                    throw ex;
                }
            }
        }
        private static IList DeserializeList( string value,Type type)
        {
            var listType = typeof (List<>).MakeGenericType(type);
            var list = JsonConvert.DeserializeObject(value, listType);
            return list as IList;
        }
