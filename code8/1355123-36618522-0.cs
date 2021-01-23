    Type type = Type.GetType(sqlDataReader["TypeName"].ToString());
    var instanceOfClass =
        Activator.CreateInstance(
                type,
                sqlDataReader["Employee_ID"].ToString(),
                sqlDataReader["Name"].ToString(),
                sqlDataReader["ContactInfo"].ToString(),
                sqlDataReader["JoinDateTime"].ToString(),
                bool.Parse(sqlDataReader["Active"].ToString()),
                sqlDataReader["Username"].ToString(),
                sqlDataReader["Password"].ToString()
        );
