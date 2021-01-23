    public List<Student> GetStudentData()
    {
        List<Student> dataStudent;
        using (IDbConnection connection = RepositoryHelper.OpenConnection())
        {
            dataStudent = connection.Query<Student, EmailAddresses, Student>(
                    "mystoredprocedure",
                    (c, cc) =>
                    {
                        c.EmailAddresses = cc;
                            return c;
                    }, 
                    commandType: CommandType.StoredProcedure, 
                    splitOn: "EmailAddress").ToList();
            }
            return dataStudent;
        }
    }
