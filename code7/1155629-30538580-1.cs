    using (NaturalGroundingVideosEntities context = new NaturalGroundingVideosEntities()) {
        SQLiteConnection Conn = (SQLiteConnection)context.Database.Connection;
        Conn.Open();
        Conn.BindFunction(new fn_CalculateSomething());
        listBox1.DataSource = (from v in context.RatingCategories
                                       select v.DbGetValue(5, 5, 5)).ToList();
    }
