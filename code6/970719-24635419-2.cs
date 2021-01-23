            class dataInfo
        {
            public int idData { get; set; }
            public string info { get; set; }
        }
        private void wv_LoadCompleted(object sender, NavigationEventArgs e)
        {
            sqliteDB cn = new sqliteDB();
            cn.open();
            string query = "SELECT * FROM data";
            List<dataInfo> placeInfo = cn.db.Query<dataInfo>(query);
            string[] args = { placeInfo[0].idData.ToString(), placeInfo[0].info };
            wv.InvokeScript("callMe", args);
            cn.close();
        }
