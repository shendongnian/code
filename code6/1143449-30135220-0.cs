    // We're selecting 3 columns now
    // 0 = Id
    // 1 = Value
    // 2 = Name
    string Query = "select Id, Value, Name from birth.store;";
    // database connection and reader execution go here
    string Value = reader.GetInt32(1).toString(); // This gets the column Value
    // This gets the column Id. Even though it's not the first one we pulled from
    // the reader, it's still #0 on the list of 3 columns.
    string Id = reader.GetInt32(0).toString(); 
    string Name = reader.GetInt32(2).toString(); // This gets the column Name
    // This will throw an exception. You're trying to get the 4th item on a list
    // that starts with 0, but there are only 3 items (numbered 0, 1, 2).
    string AnotherValue = reader.GetInt32(3).toString();
