        string _connectionString;
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (Authorize(filterContext))
            {
                return;
            }
            HandleUnauthorizedRequest(filterContext);
        }
        protected bool Authorize(AuthorizationContext httpContext)
        {
            bool isTokenAuthorized = HasValidToken();
            if(isTokenAuthorized) return true;
            return false;
        }
        protected bool HasValidToken()
        {
            string token = string.Empty;
            token = HttpContext.Current.Request.Params["token"];
            _connectionString = WebConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
            SqlTransaction txn = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                txn = conn.BeginTransaction();
                List<SqlParameter> parameters = new List<SqlParameter>();
                SqlParameter parameter = new SqlParameter();
                parameters.Add(new SqlParameter("@token", token));
                parameter = new SqlParameter("@return_ops", 0);
                parameter.Direction = ParameterDirection.Output;
                parameters.Add(parameter);
                SqlHelper.ExecuteNonQuery(txn, CommandType.StoredProcedure, "[master_LoggedInUsers]", parameters.ToArray());
                int result = Convert.ToInt32(parameters[1].Value);
                if (result <= 0)
                {
                    return false;
                }
                else return true;
            }
        }
    }
