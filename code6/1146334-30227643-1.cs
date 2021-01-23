    string words = "1sdklfjlsdf2lksjdf";
    int id = 1;
    string [] split = words.Split(new Char [] {'1', '2'});
    int deleteRecordId = id -1;
    string newString = "";
    for( int i = 0; i < split.Length; i++)
    {
        if ( i == deleteRecordId)
        {
            //ignore this record
        }
        else
        {
            newString += ++i + split[i];
        }
    }
