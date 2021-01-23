    public IHttpActionResult Test()
        {
            List<ProductPreview> gridLines;
            var cs = ConfigurationManager.ConnectionStrings["eordConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                                
                dynamicParameters.Add("UserID",1,ParameterDirection.Input);
                
                // Fill the Count in this Parameter
                dynamicParameters.Add("Count",0,ParameterDirection.Output); 
                gridLines = conn.Query<ProductPreview>("dbo.myStoredProcedure", dynamicParameters,
                 commandType: CommandType.StoredProcedure).ToList();
                 var totalCount = dynamicParameters.Get<int>("Count");
            }
           
            ....
            return Ok(gridLines);
        }
