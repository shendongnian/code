        try
        {
            con.Open();
            Console.WriteLine("Connection Open!");
            Console.WriteLine("Enter Query:");
            comString = Console.ReadLine();
            MySqlCommand myCommand = new MySqlCommand(comString, con);
            MySqlDataAdapter msda = new MySqlDataAdapter(myCommand);
            DataSet ds = new DataSet();
            msda.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
                Console.WriteLine(dr["column"].ToString());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            con.Close();
        }
