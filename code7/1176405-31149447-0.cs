    SqlCommand Comm = new SqlCommand("Command text", new SqlConnection("Connection String");
    SqlParameter[] param = {new SqlParameter("@Name","Value"), 
                            new SqlParameter("@Name","Value"),
                                ........
                                };
    Comm.Parameters.AddRange(param);
