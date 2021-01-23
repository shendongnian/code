    public interface IUserDB
    {
      List<User> Fetch();
      User Get(int ID);
    }
    public class UserDB : IUserDB
    {
      public List<User> Fetch()
      {
        List<User> users = new List<User>();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
          string query = "SELECT [Username], [EmployeeID] FROM [User];
          conn.Open();
          using (SqlCommand cmd = new SqlCommand(query, conn))
          {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
              while (reader.Read())
              {
                User user = new User();
                user.Username = reader["Username"].ToString();
                user.ID = reader["EmployeeID"].ToString();
                users.Add(user);
              }
            }
          }
        }
        return users;
      }
      public User Get(int ID)
      {
        User user = new User();
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
          string query = "SELECT [Username], [EmployeeID] FROM [User] WHERE [EmployeeID] = @ID";
          conn.Open();
          using (SqlCommand cmd = new SqlCommand(query, conn))
          {
            cmd.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = ID;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
              if (!reader.Read())
              {
                return null;
              }
              user.ID = reader["EmployeeID"].ToString();
              user.UserName = reader["Username"].ToString();  
            }
          }
        }
        return user;
      }
    }
