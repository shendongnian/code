        string conString = @"Data Source=MYIP; Port=3306; Initial Catalog=MYCATALOG; User ID=USERNAME; Password=PASS;Integrated Security=true;";
                MySqlConnection SalesKicker;
                SalesKicker = new MySqlConnection(conString);
        
                try
                {
                    SalesKicker.Open();
        
                    MySqlCommand tabCreator = new MySqlCommand("CREATE TABLE " + dt.bedrijfsNaam + " (subjects TEXT , jrLijks INT , kwrt INT , mnd INT , wek INT , dag INT)", SalesKicker);
                    tabCreator.ExecuteNonQuery();
                    MySqlCommand storeData = new MySqlCommand("INSERT INTO " + dt.bedrijfsNaam+ " (subjects, jrLijks, kwrt, mnd, wek, dag)" + "VALUES (@subjects, @jrLijks, @kwrt, @mnd, @wek, @dag)", SalesKicker);
        
                    string[] subjects = new string[] { "Prospects", "Hot Prospect", "Afspraken Maken", "Afspraken", "Offertes Maken", "Gescoorde Offertes", "Nieuwe Klanten" };
    storeData.Parameters.Add("@subjects");
    storeData.Parameters.AddWithValue("@jrLijks", dt.skProspects * 12);
                        storeData.Parameters.AddWithValue("@kwrt", dt.skProspects * 3);
                        storeData.Parameters.AddWithValue("@mnd", dt.skProspects);
                        storeData.Parameters.AddWithValue("@wek", (dt.skProspects * 12) / 52);
                        storeData.Parameters.AddWithValue("@dag", (dt.skProspects * 12) / 365);
    
                    for (int i = 0; i < subjects.Length; i++) {
                        storeData.Parameters["@subjects"].Value=subjects[i];
                        
                        //these if statements are used for every subject
                        storeData.ExecuteNonQuery();
                        
                }
        SalesKicker.Close();
