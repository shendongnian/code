                var compiler = new SqlServerCompiler();
                var query = new Query("User")
                    .Select("Id as UserId")
                    .Select("Email")
                    .Where("Id", "<", 10)
                    .Union(new Query("User")
                        .Select("Id as UserId", "Email")
                        .Where("Id", ">", 15)
                        .Where("Id", "<", 20));
                var sqlResult = compiler.Compile(query);
 
