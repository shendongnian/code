    string andOr = string.Format(" {0} (", whereAnd);
                    if ((box1)
                        || (box2)
                        || (box3)
                    {
                        whereAnd = " AND ";
                        if (box1)
                        {
                            sqlCommand.Append(andOr);
                            sqlCommand.Append("(h.object= 0)");
                            andOr = " OR ";
                        }
                        if (box2)
                        {
                            sqlCommand.Append(andOr);
                            sqlCommand.Append("(h.object= 1)");
                            andOr = " OR ";
                        }
                        if (box3)
                        {
                            sqlCommand.Append(andOr);
                            sqlCommand.Append("(h.object= 2)");
                        }
                        sqlCommand.AppendLine(")");
                    }
                   else
                    {
                        whereAnd = " WHERE ";
                        sqlCommand.Append(andOr);
                        sqlCommand.AppendLine("(h.object IS null ");
                        sqlCommand.AppendLine("))");
                        whereAnd = " AND ";
                    }
