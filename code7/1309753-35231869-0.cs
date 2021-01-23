    var _dbname = "my.db";
    var filename = "myfile.csv";
    var hasHeaderRow = true;
    var tablename = "MyTable";
    sqlite3 db;
    raw.sqlite3_open(_dbname, out db);
    raw.sqlite3_exec(db, "BEGIN");
    sqlite3_stmt stmt;
    
    using (StreamReader file = new StreamReader(filename))
    {
        string line;
        if (hasHeaderRow)
            file.ReadLine();
        while ((line = file.ReadLine()) != null)
        {
            string sql = "INSERT INTO " + tablename + " VALUES (" + String.Join(@",", SanitizeSql(line.Split(delimiter))) + ");";
            raw.sqlite3_prepare_v2(db, sql, out stmt);
            raw.sqlite3_step(stmt);
            var rc = raw.sqlite3_reset(stmt);
            raw.sqlite3_finalize(stmt);
            stmt.Dispose();
        }
    }
    raw.sqlite3_exec(db, "COMMIT");
    db.Dispose();
