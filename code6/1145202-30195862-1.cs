    namespace WcfServiceLibrary
    {  
        public class MyService: IMyService
        {
            public List<string> GetMeterBlinkData()
            { 
               List<string> result = new List<string>(); 
               string oradb = "Data Source=cecc-db1;User Id=dcsi;Password=dcsi;";
               OracleConnection conn = new OracleConnection(oradb);  // C#
               conn.Open();
               OracleCommand cmd = new OracleCommand();
               cmd.Connection = conn;
               cmd.CommandText = "select t2.meternumber, t1.blinkdate, t1.blinkcount from (select * from cecc_processed_blinks where trunc(blinkdate) between to_date('01-may-15', 'dd-mon-yy') and to_date('08-may-15', 'dd-mon-yy')) t1 left join meteraccts t2 on t1.serialnumber = t2.serialnumber order by t1.blinkdate desc";
               cmd.CommandType = CommandType.Text;
               OracleDataReader dr = cmd.ExecuteReader();
               dr.Read();
                //TODO loop through results and fill the results object
               conn.Dispose();
               return result;
            }
        }
    }
