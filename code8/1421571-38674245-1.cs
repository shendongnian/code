    using System;
    using System.Data;
    using System.Data.SqlClient;
    
    class Program
    {
        static void Main()
        {
            string str = "my connection string";
            ReadData(str, "3");
        }
    
        private static void ReadData(string connectionString, string childId)
        {
            string queryString = @"WITH R (GroupID, Name, ParentID, level)
    AS (
       select GroupID, Name, ParentGroupID, 1
       from Groups
       where GroupID = " + childId + @"
       union all
       select R.GroupID, R.Name, t.ParentGroupID, level + 1
       from R
       join Groups t
         on (R.ParentID = t.GroupID and t.ParentGroupID <> t.GroupID)
    )
    select R.GroupID, g.Name as ParentName, R.level, R.Name as GroupName, R.ParentID
    from R
    left join Groups g on (R.ParentID = g.GroupID)
    where g.Name IS NOT NULL
    order by R.groupID, R.level, R.ParentID";
    
            using (SqlConnection connection =
                       new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
    
                SqlDataReader reader = command.ExecuteReader();
    
                while (reader.Read())
                {
                    Console.WriteLine(String.Format("{0} {1}", record[0], record[1]));
                }
    
                reader.Close();
            }
        }
    
    }
