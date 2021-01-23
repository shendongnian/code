     SqlCommand SC1 = new SqlCommand("select distinct City from Final 
                                     where City!='' and city is not null 
                                      and Published like'%/%/" + 
                                     DateTime.Now.ToString("yyyy") + "'", conn);
     SqlDataAdapter SDA1 = new SqlDataAdapter(SC1);
     Global.CityTable = new DataTable();
     SDA1.Fill(Global.CityTable);
