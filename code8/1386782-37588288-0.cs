    var mytimer = new System.Timers.Timer(1000);
    mytimer.Elapsed += Mytimer_Elapsed;
    mytimer.Start();
    private static object lockobject = new object();
    private static void Mytimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        lock(lockobject)
        {
            cn.Open();
    
            try
            {
                MySqlCommand cmd = new MySqlCommand("insert into supervision values("...........')", cn);
                /
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MySqlCommand cmd2 = new MySqlCommand("insert into supervision values(" +.......')", cn);
        
    
                    cmd2.ExecuteNonQuery();
                }
            }
            cn.Close();
            MessageBox.Show("database added");
        }
    }
