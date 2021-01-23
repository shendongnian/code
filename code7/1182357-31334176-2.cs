    public void Load(CustomTest obj, Guid RequestId)
    {
        using (var con = base.GetClosedConnection())
        {
            con.Open();                
    
            //result is list of CustomTest
            var result = db.Query<CustomTest>("GetRequestTest", new {RequestId},
                             commandType: CommandType.StoredProcedure);
        }            
    }
