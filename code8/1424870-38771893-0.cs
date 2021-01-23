    async Task MyMethod()
    {
        var sql = new ProjetTN.Class.SQLite();
        await sql.CallGetSens(); 
        var SensItems = sql.ListeSens();
        ...
    }
