    public static List<Tool_OP> list = new List<Tool_OP>();
    BinaryReader fs = new BinaryReader(File.Open(FileName, FileMode.Open));
    bool isValidReadRecord = true;
    while(isValidReadRecord)
    {
        Tool_OP item = new Tool_OP();
        isValidReadRecord = item.ReadRecord(fs);
        
        if(isValidReadRecord)
        {
            list.Add(item);
        }
    };
    fs.Close();
