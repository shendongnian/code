    using System;
    using System.Data;
    using System.Data.OracleClient;
    
    namespace TestApp
    {
        class Program
        {
            static void Main()
            {
                string connectionString = "Data Source=ThisOracleServer;Integrated Security=yes;";
                string queryString = @"merge into test2 a
                                        using test1 b
                                            on (a.t2_NAME = b.t1_NAME)
                                        when matched then update
                                            set a.t2_fNAME = TRIM(b.t1_fNAME),
                                                a.ACCOUNT_NUMBER = TRIM(b.ACCOUNT_NO),
    
                                        when not matched then
                                        insert (t2_slno,t2_NAME,t2_fNAME,ACCOUNT_NUMBER)
                                        values (t2_NODE_SEQ.NEXTVAL, b.t1_NAME,TRIM(b.t1_fNAME),TRIM(b.ACCOUNT_NO));";
    
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    using (OracleCommand command = connection.CreateCommand())
                    {
                        command.CommandText = queryString;
    
                        try
                        {
                            connection.Open();
                            command.ExecuteScalar();
                        }
                        catch (Exception ex)
                        {
                            //Log Exception here;
                            throw;
                        }
                    }
                }
            }
        }
    }
