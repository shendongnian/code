    public class Foo
        {
            public void Bar()
            {
                SimpleClass.InvokeSql((connection) =>
                    {
                        string sql = "DELETE [User]";
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    });
            }
        }
