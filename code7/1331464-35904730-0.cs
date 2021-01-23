    public static void BackupDB(Server srv, Database db, string savePath)
    {
        string objPath;
        string objFile;
        string objTxt;
        BackupObjects(db.StoredProcedures.Cast<StoredProcedure>().Where(x => !x.IsSystemObject));
        BackupObjects(db.Tables.Cast<Table>().Where(x => !x.IsSystemObject));
    }
    private static void BackupObjects(IEnumerable<ScriptSchemaObjectBase> objects)
    {
        foreach (ScriptSchemaObjectBase obj in objects)
        {
            objPath = savePath + "Stored Procedures\\";
            Directory.CreateDirectory(objPath);
            objFile = objPath + obj.Schema + "." + obj.Name + ".sql";
            objTxt = GetScriptString(srv, obj);
            File.WriteAllText(objFile, objTxt);
        }
    }
