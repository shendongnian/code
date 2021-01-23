        /* Code from Stack Overflow Answer */
    
    using (SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["T3"])) {
            cn.Open();
            using (SqlTransaction tr = cn.BeginTransaction()) {
                //some code
                tr.Commit();
            }
        }
