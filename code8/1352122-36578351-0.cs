     string Query = "UPDATE  `11.04.2016` AS t1 INNER JOIN  `10.04.2016` AS t2 ON t1.id = t2.id SET t1.xx = t2.yy";
            //This is  MySqlConnection here i have created the object and pass my connection string.  
            //   MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
            MySqlCommand cmd2 = new MySqlCommand(Query, conn);
            MySqlDataReader MyReader2;
            conn.Open();
            MyReader2 = cmd2.ExecuteReader();
            MessageBox.Show("Data Updated");
            while (MyReader2.Read())
