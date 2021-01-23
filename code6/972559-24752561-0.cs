                if (intern.Id > 0)
                {
                    if (parameterCount == 0)
                        sql += "WHERE \"Id\"=";
                    if (parameterCount > 0)
                        sql += "AND \"Id\"=";
                    IdParam.Value = intern.Id;
                    sql += "@Id ";
                    cmd.Parameters.Add(IdParam);
                    parameterCount++;
                }
                if (intern.Name != "" && intern.Name != null)
                {
                    if (parameterCount == 0)
                        sql += "WHERE \"Name\" ILIKE ";
                    if (parameterCount > 0)
                        sql += "AND \"Name\" ILIKE ";
                    NameParam.Value = intern.Name;
                    sql += "@Name ";
                    cmd.Parameters.Add(NameParam);
                    parameterCount++;
                }
