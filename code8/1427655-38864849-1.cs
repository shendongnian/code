    private List<DataModel> getData(double latitude, double longitude, int radius)
    { 
        SqlParameter[] param = 
                         {
                            new SqlParameter("@lat", latitude),
                            new SqlParameter("@lon", longitude),
                            new SqlParameter("@rad", radius)
                         };          
      //Call stored procedure
      var data db.Database.SqlQuery<DataModel("Haversine,param)
      return data.ToList();
    } 
