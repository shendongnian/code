    public void create(account_detail c, List<int> jobcard_ids)
            {
                SqlConnection con = new SqlConnection(@"Data source =(LocalDB)\v11.0;AttachDbFilename=C:\Users\Wattabyte Inc\Documents\CarInfo.mdf;Integrated Security=True;");
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
               string additionalText = string.Empty;
                 bool needComma = false;
    
                 foreach (var details in c.Data)
                  {
                     if (needComma)
                     {
                          additionalText += ", ";
                     }
    
                          else
                     {
    
                         needComma = true;
                      foreach(var jobcard_id in jobcard_ids)
                      {
                         additionalText += "('" + jobcard_id + "','" + details.completed_by + "','" + details.reporting_time + "','" + details.cost_activity + "','" + details.spared_part_used + "')";
                         if (jobcard_id != jobcard_ids.Last())
                         {
                             // We will need to comma separate the query string unless it's the last item
                             additionalText+= ","; 
                         }
                      }
                    }
                     cmd.CommandText = "insert into child_detail values " + additionalText + ";";
                     cmd.ExecuteNonQuery();
    
                  }
