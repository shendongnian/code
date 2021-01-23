    try
            {
                con.connect();// first you must connect to the database
                var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem);
                query = "select * from tbale_name";
                cmd = new SqlCommand(query, con.DBConn);
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    adapter.Add("" + dataReader["column_name"].ToString() + "");
                }
                var spinner1 = FindViewById<Spinner>(Resource.Id.spn_spouseName);
                spinner1.Adapter = adapter;
            }
            catch (Exception)
            {
            }
