            //ON MY FIRST FORM
            //this is my connection - add it anywhere you want
            //or change it according to your need
            NpgsqlConnection iConnect = new NpgsqlConnection("Server = " + myModule.Server + ";Port = " + myModule.Port + ";User ID = " + myModule.UserID + ";Password = " + myModule.Password + ";Database = " + myModule.Database);
            iConnect.Open();
            NpgsqlCommand iQuery = new NpgsqlCommand("Select * from Table1");
            iQuery.Connection = iConnect;
            NpgsqlDataAdapter iAdapter = new NpgsqlDataAdapter(iQuery);
            DataSet iDataSet = new DataSet();
            iAdapter.Fill(iDataSet, "SET");
            myModule.dtSet = iDataSet;//pass the dataset to myModule.cs
