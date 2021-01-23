    private class DatabaseHelper : SQLiteOpenHelper{
    	internal DatabaseHelper(Context context)
    		: base(context, dBName, null, databaseVersion){
    	}
    	public override void OnCreate(SQLiteDatabase db){
    	   db = SQLiteDatabase.OpenDatabase (destinationPath, null, 0);
    	}
    	public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion){
    		Log.Wtf(tag, "Upgrading database from version " + oldVersion + " to " + newVersion + ", which will destroy all old data");
    		this.OnCreate(db);
    	}
    }
