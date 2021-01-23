    string [] split = words.Split(new Char [] {'1', '2', ...});
    deleteRecordId = id -1;
    string newString = ""
    for( int i = 0; i < split.Length; i++)
    {
        if ( i == deleteRecordId)
        {
            //ignore this record
        }
        else
        {
            newString += split[i];
        }
    }
