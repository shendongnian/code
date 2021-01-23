        if (reader.Read())
        {
            employee.uid = reader.GetString(reader.GetOrdinal("uid"));
            employee.Name = reader.GetString(reader.GetOrdinal("name"));
            employee.dob = reader.GetString(reader.GetOrdinal("dob"));
            employee.work_loc = reader.GetString(reader.GetOrdinal("work_loc"));
            employee.mobile = reader.GetString(reader.GetOrdinal("mobile"));
            // closing the connection pool
            reader.Close();
            con.Close();
            return employee;
        }
        else 
        {
            return null;
        }
