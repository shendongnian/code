     public class Employess : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            jss.MaxJsonLength = Int32.MaxValue;
            string json;
            string prefixText = context.Request.QueryString["query"];
            using (var rep = new RBZPOS_CSHARPEntities())
            {
                var result = rep.Employees
                                 .Where(x => x.EMPLOYEESTATE == 1 && x.FULLNAME.Contains(prefixText.ToUpper()))
                                 .Select(x => new
                                 {
                                     x.EMPLOYEEID,
                                     x.FULLNAME,
                                     x.MANNO,
                                     x.NRC
                                 }).ToArray();
                json = jss.Serialize(result);
            }
            context.Response.ContentType = "text/javascript";
            context.Response.Write(json);
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
