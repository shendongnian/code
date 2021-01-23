    public static int insertUpdate(Object data) {
        string path = DB.pathToDatabase ();
        DB.createDatabase ();
        try {
            var db = new SQLiteConnection(path);
            int inserted = db.Insert(data); //will be 1 if successful
            if (inserted > 0)
                return data.Id; //Acording to the documentation for the SQLIte component, the Insert method updates the id by reference
            return inserted;
        }
        catch (SQLiteException ex) {
            return -1;
        }
    }
