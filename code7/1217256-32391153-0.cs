      do
        {
          if (reader.HasRows)
         {
             while (reader.Read())
             {
                   DefMeetingDTO d = new DefMeetingDTO();
                  if (!reader.IsDBNull(reader.GetOrdinal("md_id")))
                  {
                       d.md_id = Convert.ToInt32(reader["md_id"]) as int? ?? default(int);
                  }
                  else
                  {
                       d.md_id = 0;
                  }
                  AllDefCompany.Add(d);
               }
         }
      }
         while(reader.NextResult());  
    
