            while ((line = file.ReadLine()) != null)
            {
                line = line.Trim();
                line = line.TrimEnd(',', ',',',', '.');
                cmd.CommandText = const_state + line+";";
                try 
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    // dump cmd.CommandText somewhere as well as 
                    // the actual exception details
                    //
                    // that'll give you two things: 1) the specific 
                    // issue, and 2) the actual INSERT statement that 
                    // failed
                }
                i++;
            }
