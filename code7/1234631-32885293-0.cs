    model.Wells = new List<WellModel>();
    using (SQLiteConnection con = new SQLiteConnection(cs))
    {
    ....
    while (rdr.Read())
    {
        WellModel well = new WellModel
            {
                SlideId = rdr["SlideId"].ToString(),
                Well = int.Parse(rdr["Well"].ToString()),
                TimeStamp = rdr["TimeStamp"].ToString()
            };
        model.Wells.Add(well);
    }
