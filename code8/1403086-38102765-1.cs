            {
            bool outcome = false;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this.sql_conn;
            cmd.Parameters.AddWithValue("BatteryType", b.BatteryType);
            cmd.Parameters.AddWithValue("VoltageMax", b.Vmax);
            cmd.Parameters.AddWithValue("Capacity", b.Capacity);
            cmd.Parameters.AddWithValue("CurrentMax", b.Imax);
            cmd.Parameters.AddWithValue("Manufacturer", b.Manufacturer.ToString());
            cmd.Parameters.AddWithValue("Serial", b.Serial.ToString());
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Inserted Battery Successfully");
                outcome = true;
            }
            catch(Exception e)
            {
                MessageBox.Show("SQL INSERT error \n\n" + e.Message);
            }
            return outcome;
        }
