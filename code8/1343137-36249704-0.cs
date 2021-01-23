    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    
    namespace DemoNameSpace
    {
        public class DemoClassDAL
        {
            private CheckResult UserExist()
            {
                CheckResult result = CheckResult.NoDuplicate;
    
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegistrationConnectionString"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand(@"select top 1
                                                        case
                                                            when AdminNo = @AdminNo  then 'AdminExists'
                                                            when Username = @UserName then 'UserExists'
                                                            when RegisterNo = @RegisterNo then 'RegisterNoExists'
                                                        end as Result
                                                      From Register");
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;
                    conn.Open();
    
                    var dbresult = cmd.ExecuteScalar();
                    conn.Close();
    
                    if (dbresult != DBNull.Value)
                    {
                        Enum.TryParse(dbresult.ToString(), out result);
                    }
                }
    
                return result;
            }
        }
    
        public enum CheckResult
        {
            NoDuplicate,
            AdminExists,
            UserExists,
            RegisterNoExists
        }
    }
