       {
           var selectedidlist = new List<string>();
           for (var rownum = 0; rownum < dataGridView1.Rows.Count; rownum++)
           {
               if (dataGridView1.Rows[rownum].Cells["Column1"].Value!=null && ((bool)(dataGridView1.Rows[rownum].Cells["Column1"]).Value))
               {
                   selectedidlist.Add(dataGridView1.Rows[rownum].Cells["USN"].Value.ToString());
 
               }
           }
 
           if (selectedidlist.Count > 0)
           {
 
               var selectedListString = selectedidlist.Aggregate((current, next) => current + ", " + next);
 
               String str = "delete  from T_BOOK_ISSUE_TABLE where USN in (@search)";
               SqlCommand xp = new SqlCommand(str, vid);
               xp.Parameters.Add("@search", SqlDbType.NVarChar).Value = selectedListString;
 
               vid.Open();
               xp.ExecuteNonQuery();
               vid.Close();
               Delete_Load(null, null);
           }
