    using System;
    using System.Data;
    using System.Threading;
    using System.Diagnostics;
    using MySql.Data.MySqlClient;
    
    namespace MemSQLTest {
      //Thread creates a connection and inserts for 1000 milliseconds
      public class WorkerThread {
        public static void Thread() {
          try {
            IDbConnection conn;
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            conn.ConnectionString = "Server=127.0.0.1;Uid=root;Pwd=;";
            conn.Open();
    
            IDbCommand dbcmd = conn.CreateCommand();
            dbcmd.CommandText = "USE db";
            dbcmd.ExecuteNonQuery();
            dbcmd.CommandText = "INSERT INTO t VALUES (DEFAULT)";
            Stopwatch stop = new Stopwatch();
            stop.Start();
            while(stop.ElapsedMilliseconds < 1000)
            {
              dbcmd.ExecuteNonQuery();
            }
          } catch (Exception ex) {
              Console.WriteLine(ex.Message);
          }
        }
      }
      class MemSQLTest {
        static void Main(string[] args) {
          try {
            IDbConnection conn;
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            conn.ConnectionString = "Server=127.0.0.1;Uid=root;Pwd=;";
            conn.Open();
    
            //Initialize database with auto increment table
            IDbCommand dbcmd = conn.CreateCommand();
            dbcmd.CommandText = "DROP DATABASE IF EXISTS db";
            dbcmd.ExecuteNonQuery();
            dbcmd.CommandText = "CREATE DATABASE db";
            dbcmd.ExecuteNonQuery();
            dbcmd.CommandText = "USE db";
            dbcmd.ExecuteNonQuery();
            dbcmd.CommandText = "CREATE TABLE t (id int primary key auto_increment)";
            dbcmd.ExecuteNonQuery();
            //Initialize threads
            Thread[] threads = new Thread[10];
            for(int i = 0; i < 10; i++)
            {
              threads[i] = new Thread(new ThreadStart(WorkerThread.Thread));
              threads[i].Start();
            }
            for(int i = 0; i < 10; i++)
            {
              threads[i].Join();
            }
            //Show select count(*) on auto increment table
            dbcmd.CommandText = "SELECT COUNT(*) FROM t";
            IDataReader reader = dbcmd.ExecuteReader();
            while(reader.Read()) {
              Console.WriteLine(reader["COUNT(*)"]);
            }
          } catch (Exception ex) {
            Console.WriteLine(ex.Message);
          }
        }
      }
    }
