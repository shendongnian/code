            using (SqlConnection connection = new SqlConnection("...connection string ..."))
            {
                SqlCommand command = new SqlCommand("insert into Orders(client_id,order_id,date_,card_typ,pay_mthd,ex_y,ex_m,cc_comp,cc_num,t_sale)values(@client_id,@order_id,@date_,@card_typ,@pay_mthd,@ex_y,@ex_m,@cc_comp,@cc_num,@t_sale)", connection);
                SqlParameter pclient_id = new SqlParameter("@client_id", System.Data.SqlDbType.Int);
                pclient_id.Value = 12;
                command.Parameters.Add(pclient_id);
                SqlParameter pcard_typ = new SqlParameter("@card_typ", System.Data.SqlDbType.VarChar);
                pcard_typ.Value = "some value";
                command.Parameters.Add(pcard_typ);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
