    public void Load(CustomTest obj, Guid RequestId)
    {
        using (var con = base.GetClosedConnection())
        {
            con.Open();
    
            var p = new DynamicParameters();
            p.Add("@RequestId", dbType: DbType.Guid, direction: ParameterDirection.Input);               
    
            //result is list of CustomTest
            var result = db.Query<CustomTest>("GetRequestTest", p, commandType: CommandType.StoredProcedure);
    
        }            
    }
