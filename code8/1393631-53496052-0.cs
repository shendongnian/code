     DateTime time = DateTime.Now;
    String result = time.ToString("HH:mm ");
    
     DateTime firstTimr = DateTime.ParseExact(reader["shift_start_time"].ToString(), "HH:mm:tt", null);
     String firstTimr1 = firstTimr.ToString("HH:mm ");
    DateTime lastTime = DateTime.ParseExact(reader["Shift_last_time"].ToString(), "HH:mm:tt", null);
    String lastTime1 = lastTime.ToString("HH:mm ");
    
    if (DateTime.Parse(result) >= DateTime.Parse(firstTimr1) && (DateTime.Parse(result) <= DateTime.Parse(lastTime1)))
                        {
                           `enter code here` MessageBox.Show("First Shit");
                           
                        }
