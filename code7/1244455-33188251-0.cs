        public async List<string> GetListTables(string DBName)
        {
            List<string> tablesList = new List<string>();
            string itemName = null;
            var con = new SQLiteAsyncConnection(DBName);
            var query = await con.QueryAsync<sqlite_master>("SELECT name FROM sqlite_master WHERE type='table' AND NOT SUBSTR(name,1,6) = 'sqlite' ORDER BY name");        
            foreach(var tablesItem in query)
            {
                itemName = "\n" + tablesItem.name + "\n\n";
                tablesList.Add(itemName);
            }
            return tablesList;
        }
