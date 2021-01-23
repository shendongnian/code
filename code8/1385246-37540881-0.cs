        foreach (GridViewRow g1 in GridView1.Rows)
                    {
                        SqlConnection con = new SqlConnection(connStr);
                        com = new SqlCommand("insert into student(sid,sname,smarks,saddress) values ('" + g1.Cells[0].Text + "','" + g1.Cells[1].Text + "','" + g1.Cells[2].Text + "','" + g1.Cells[3].Text + "')", con);
                        con.Open();
                        com.ExecuteNonQuery();
                        con.Close();
         
                    }
