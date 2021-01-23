    using (SqlConnection cons = new SqlConnection(constr))
            {           
                using (SqlCommand cmds = new SqlCommand(query))
                {
                    cons.Open();
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmds.CommandType = CommandType.Text;
                        cmds.Connection = cons;
                        sda.SelectCommand = cmds;
                        **sda.Fill(dt);** //Error occurs here
                    }
                }
                return dt;
            }
