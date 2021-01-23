        SqlCommand myCommand = new SqlCommand("select * from colege where name like'" + item + "'",
                                                    myConnection);
        myReader = myCommand.ExecuteReader();
        while (myReader.Read())
        {
            colegeid = myReader["id"].ToString();
            //    Console.WriteLine(myReader["Column2"].ToString());
        }
