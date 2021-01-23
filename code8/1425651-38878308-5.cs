        public HttpResponseMessage Getdetails([FromUri] string[] id)
        {
            var prms = new List<OracleParameter>();
            var connStr = ConfigurationManager.ConnectionStrings["PDataConnection"].ConnectionString;
            var inconditions = id.Distinct().ToArray();
            var strQuery = @"SELECT 
                           STCD_PRIO_CATEGORY_DESCR.DESCR AS CATEGORY, 
                           STCD_PRIO_CATEGORY_DESCR.SESSION_NUM AS SESSION_NUMBER, 
                           Trunc(STCD_PRIO_CATEGORY_DESCR.START_DATE) AS SESSION_START_DATE, 
                           STCD_PRIO_CATEGORY_DESCR.START_DATE AS SESSION_START_TIME , 
                           Trunc(STCD_PRIO_CATEGORY_DESCR.END_DATE) AS SESSION_END_DATE, 
                             FROM 
                             STCD_PRIO_CATEGORY_DESCR, 
                             WHERE 
                            STCD_PRIO_CATEGORY_DESCR.STD_REF IN(";
            var sb = new StringBuilder(strQuery);
            for (int x = 0; x < inconditions.Length; x++)
            {
                sb.Append(":p" + x + ",");
                var p = new OracleParameter(":p" + x, OracleDbType.NVarchar2);
                p.Value = inconditions[x];
                prms.Add(p);
            }
            if (sb.Length > 0)// Should this be inconditions.Length > 0  ?
                sb.Length--;
            strQuery = sb.Append(")").ToString();
            var returnObject = new { data = new OracleDataTableJsonResponse(connStr, strQuery, prms.ToArray()) };
            var response = Request.CreateResponse(HttpStatusCode.OK, returnObject, MediaTypeHeaderValue.Parse("application/json"));
            ContentDispositionHeaderValue contentDisposition = null;
            if (ContentDispositionHeaderValue.TryParse("inline; filename=ProvantisStudyData.json", out contentDisposition))
            {
                response.Content.Headers.ContentDisposition = contentDisposition;
            }
            return response;
        }
