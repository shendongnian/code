    using (var connection = new SqlConnection("Data Source=.;Initial Catalog=Test;Integrated Security=SSPI;"))
                {
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT *   FROM [Test].[dbo].[SomeDates] WHERE dt > @MyDate";
                        var param = new SqlParameter("@MyDate", SqlDbType.DateTime2) { Value = DateTime.Now };
                        command.Parameters.Add(param);
                        var result = command.ExecuteReader();
                        while (result.Read())
                        {
                            Console.WriteLine(result.GetDateTime(0));
                        }
                    }
                }
