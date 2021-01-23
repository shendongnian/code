    #define TRACE
    using System;
    using System.Web;
    using System.Data.SqlClient;
    using System.Web.Hosting;
    
    public class SqlLoggingModule : IHttpModule {
        public void Dispose() {
        }
    
        public void Init(HttpApplication context) {
            context.LogRequest += new EventHandler(OnLogRequest);
        }
    
        void OnLogRequest(object sender, EventArgs e) {
            HttpApplication app = (HttpApplication)sender;
            try {
                Log(app.Context);
            }
            catch (Exception ex) {
                System.Diagnostics.Trace.TraceError(ex.ToString());
    
                app.Context.Trace.Warn(ex.ToString());
            }
        }
    
        private void Log(HttpContext ctx) {
            string connectionString = @"server=(local);database=TechEd;uid=youruser;password=yourpassword;";
    
            // Disable Kernel Cache
            ctx.Response.DisableKernelCache();
    
            using (SqlConnection connection = new SqlConnection(connectionString)) {
    
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText =
                    "insert into Log (Date, Method, IPAddress, Url, UserName, UserAgent, ResponseCode, SiteName, ApplicationName) values" +
                                  "(@Date, @Method, @IPAddress, @Url, @UserName, @UserAgent, @ResponseCode, @SiteName, @ApplicationName)";
    
                cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                cmd.Parameters.AddWithValue("@Method", ctx.Request.HttpMethod);
                cmd.Parameters.AddWithValue("@IPAddress", ctx.Request.UserHostAddress);
                cmd.Parameters.AddWithValue("@Url", ctx.Request.Url.ToString());
                cmd.Parameters.AddWithValue("@UserName", ctx.Request.ServerVariables["LOGON_USER"]);
                cmd.Parameters.AddWithValue("@UserAgent", ctx.Request.UserAgent);
                cmd.Parameters.AddWithValue("@ResponseCode", ctx.Response.StatusCode + "." + ctx.Response.SubStatusCode);
                cmd.Parameters.AddWithValue("@SiteName", HostingEnvironment.SiteName);
                cmd.Parameters.AddWithValue("@ApplicationName", ctx.Request.ApplicationPath);
    
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
