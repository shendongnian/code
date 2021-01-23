     public class PodborsByParametersService
    {
        string _connectionString = null;
      
        public PodborsByParametersService(string connStr)
        {
            this._connectionString = connStr;
        }
                
        public IList<TyreSearchResult> GetTyres(TyresPodborView pb,bool isPartner,string partnerId ,int pointId)
        {
         
            string sqltext  "spGetTyresPartnerToClient";
            var p = new DynamicParameters();
            p.Add("@PartnerID", partnerId);
            p.Add("@PartnerPointID", pointId);
                        
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<TyreSearchResult>(sqltext, p,null,true,null,CommandType.StoredProcedure).ToList();
            }
         
            }
    }
