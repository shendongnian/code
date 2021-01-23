    public override void Up()
    {
        string sqlResName = typeof(RunSqlScript).Namespace  + ".201801310940543_RunSqlScript.sql";
        this.SqlResource(sqlResName );
    }
