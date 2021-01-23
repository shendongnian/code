    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ParallelDBProcessing
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Task> taskList = new List<Task>();
                for (int i = 1; i <= 4; i++)
                {
                    int temp = i;
                    Task task = Task.Run(() => DoWork(temp));   // use Task.Run if you want to get task.Result back
                    taskList.Add(task);
                }
                Task.WaitAll(taskList.ToArray());
            }
    
            public static void DoWork(int num)
            {
                Console.WriteLine(num);
                string connstr = @"Data Source = (local)\sqlexpress; Initial Catalog = Barry; Integrated Security = true";
    
                DataSet dsResults = new DataSet();
                using (SqlCommand sqlCmd = new SqlCommand("dbo.[spMagicProc]"))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
    
                    SqlParameter parm = new SqlParameter("@Input_A", SqlDbType.Int);
                    parm.Value = num;
                    sqlCmd.Parameters.Add(parm);
    
                    SqlParameter parm1 = new SqlParameter("@Input_B", SqlDbType.Int);
                    parm1.Value = 2;
                    sqlCmd.Parameters.Add(parm1);
    
                    using (SqlConnection conn = new SqlConnection(connstr))
                    {
                        sqlCmd.Connection = conn;
    
                        using (SqlDataAdapter da = new SqlDataAdapter(sqlCmd))
                        {
                            try
                            {
                                conn.Open();
                                da.Fill(dsResults);
                                conn.Close();
                            }
                            catch (Exception ex)
                            {
                                throw;
                            }
                            finally
                            {
                                if (conn.State != ConnectionState.Closed)
                                    conn.Close();
                            }
                        }
    
                    }
                    Console.WriteLine(dsResults.Tables[0].Rows.Count);
                }
            }
        }
    }
