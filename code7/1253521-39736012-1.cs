    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                var constring = (new SqlConnectionStringBuilder
                {
                    DataSource = "someserver",
                    InitialCatalog = "12trunk",
                    IntegratedSecurity = true
                }).ToString();
                using (var con = new SqlConnection(constring))
                {
                    con.Open();
                    using (var trans = con.BeginTransaction(isolationLevel: System.Data.IsolationLevel.ReadUncommitted) as SqlTransaction)
                    using (var cmd = new SqlCommand())
                    {
                        cmd.Transaction = trans;
                        cmd.Connection = con;
                        var start = DateTime.Now;
                        Console.WriteLine("Start = " + start);
                        const int inserts = 100000;
                        var builder = new StringBuilder();
                        cmd.CommandText = "delete from test";                    
                        for (int i = 0; i < inserts; i++)
                        {
                            Guid[] guids = new Guid[7];
                            for (int j = 0; j < 7; j++)
                            {
                                guids[j] = Guid.NewGuid();
                            }
                            var sql = $"insert into test (f0, f1, f2, f3, f4, f5, f6) values ('{guids[0]}', '{guids[1]}', '{guids[2]}','{guids[3]}', '{guids[4]}', '{guids[5]}', '{guids[6]}');\n";
                            builder.Append(sql);
                            if (i % 1000 == 0)
                            {
                                cmd.CommandText = builder.ToString();
                                cmd.ExecuteNonQuery();
                                builder.Clear();
                            }
    
                        }
                        cmd.CommandText = builder.ToString();
                        cmd.ExecuteNonQuery();
                        trans.Commit();
                        var ms = (DateTime.Now - start).TotalMilliseconds;
                        Console.WriteLine("Ms to run = " + ms);
                        Console.WriteLine("inserts per sec = " + inserts / (ms / 1000));
                        Console.ReadKey();
                    }
                }
            }
        }
    }
