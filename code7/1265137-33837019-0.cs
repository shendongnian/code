    static void Main(string[] args)
    {
        using(OleDbConnection connLocal = new OleDbConnection(...))         
        using(OleDbCommand cmdLocal = new OleDbCommand("SELECT tran_num, provider_id, amount, tran_date, collections_go_to, impacts, type, 'TestClinic' AS Clinic FROM transactions WHERE tran_date > '2015-09-27'", connLocal))
        using(StreamWriter sqlWriter = new StreamWriter(@"C:\Users\Administrator\Desktop\Clinic.txt"))
        {
            try
            {
                connLocal.Open();
                using(OleDbDataReader readLocal = cmdLocal.ExecuteReader())
                {
                     while (readLocal.Read())
                     {
                        sqlWriter.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}", 
                        readLocal.GetValue(0).ToString(), 
                        readLocal.GetValue(1).ToString(),
                        readLocal.GetValue(2).ToString(), 
                        readLocal.GetValue(3).ToString(), 
                        readLocal.GetValue(4).ToString(), 
                        readLocal.GetValue(5).ToString(), 
                        readLocal.GetValue(6).ToString(), 
                        readLocal.GetValue(7).ToString());
                    }
                }
                sqlWriter.Flush();
           }
           catch (Exception connerr) { Debug.WriteLine(connerr.Message); }
       }
    }
