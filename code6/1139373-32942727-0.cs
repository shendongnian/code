    con.Open();
                string sqlQuery = "SELECT TOP 1 kode_user from USERADM order by kode_user desc";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                SqlDataReader dr = cmd.ExecuteReader();
    
                while (dr.Read())
                {
                    string input = dr["kode_user"].ToString();
                    string angka = input.Substring(input.Length - Math.Min(3, input.Length));
                    int number = Convert.ToInt32(angka);
                    number += 1;
                    string str = number.ToString("D3");
    
                    txtKodeUser.Text = "USR" + str;
                }
                con.Close();
