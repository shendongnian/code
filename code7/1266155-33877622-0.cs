    public class myObj
        {
            public string Sid { get; set; }
            public string Serial { get; set; }
            public Double RunTime { get; set; }
            public string Username { get; set; }
            public string LogonTime { get; set; }
            public string SqlText { get; set; }
            public string Database { get; set; }
            public bool Terminated { get; set; }
    
            public myObj()
            {
            }
            public myObj(DataRow row)
            {
    
                myObj Session = new myObj();
                myObj.Sid = row["SID"].ToString();
                myObj.Serial = row["SERIAL#"].ToString();
                myObj.Username = row["USERNAME"].ToString();
                myObj.RunTime = Convert.ToDouble(row["RUN_TIME"].ToString());
                myObj.LogonTime = row["LOGON_TIME"].ToString();
                myObj.SqlText =  row["SQL_FULLTEXT"].ToString();
                myObj.Database = row["DATABASE"].ToString();
                return Session ;
            }
        }
    
        Dictionary<myObj,string > result =
                        table.AsEnumerable()
                            .ToDictionary(
                                row => new myObj(row), row => row["USERNAME"].ToString() + "|" + row["SQL_FULLTEXT"].ToString());
