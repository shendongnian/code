    public static logger
    {
     public DataTable DTLog = new DataTable();
    
    public static void BuldDTLog()
            {
                DTLog.Columns.Add("Time");
                DTLog.Columns.Add("Type");
                DTLog.Columns.Add("Level");
                DTLog.Columns.Add("Text");
            }
    
            public static void AppendtoLog(String Level, String Type, String Text)
            {
    
                DTLog.Rows.Add(DateTime.Now, Level, Type, Text);
    
            }
    }
    public class otherClass
    {
    logger.BuldDTLog();
    logger.AppendtoLog(param1,param2,param3);
    }
