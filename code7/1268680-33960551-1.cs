    using System; 
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data.Interfaces;
    using Data.Models;
    using System.Data.SqlClient;
    using System.Data;
    using System.Web;
    namespace Data
    {
        public class UserEntity:IUser, IDisposable
        {
            private string mSqlCnn;
        
            public UserEntity(string SqlCnn)
            {
                mSqlCnn = SqlCnn;
            }
            public void Dispose()
            {
                mSqlCnn = null;
            }
            public int Entrar(User pUser)
            {
                int logresult = 0;
    
			    //SqlConnection is IDisposable, and it occupies from closing connection.
			    using(SqlCOnnection mSqlConnection = new SqlConnection(mSqlCnn))
			    {
				    try
				    {
					    mSqlConnection.Open();					
					    mSqlCommand = new SqlCommand("OpMngSys.USP_CostumerLogin",mSqlConnection);
					    mSqlCommand.CommandType = CommandType.StoredProcedure;
					    //Add Input Parameters
					    mSqlCommand.Parameters.Add("@UserName", SqlDbType.VarChar).Value = pUser.UserName;
					    mSqlCommand.Parameters.Add("@Password", SqlDbType.VarChar).Value = pUser.Password;
					
					    //Declare output parameter that will receive the result
					    SqlParameter outputIsExists = new SqlParameter("@IsExists", SqlDbType.Int) {
						    Direction = ParameterDirection.Output
						    };
					    mSqlCommand.Parameters.Add(outputIsExists);
					
					    //ExecuteNonQuery won't give any result
					    mSqlCommand.ExecuteNonQuery();
					
					    //Get the value that has been set by the StoredProcedure in the output parameter
					    logresult = (int)outputIsExists.Value
				    }
				    catch (Exception ex)
				    { throw ex; }
			    }
			
			    return logresult;
            }
            public int Create(User pUser)
            {
                return 0;
            }
            //public int Delete(User pUser)
            //{
            //    return 0;
            //}
        }
    }
