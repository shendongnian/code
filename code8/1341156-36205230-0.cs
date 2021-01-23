                if (box1 || box2 || box3)
                {
                    var op = " AND (";
                    if (box1)
                    {
                        sqlCommand.Append(op);
                        sqlCommand.Append("(h.object= 0)");
                        op = " OR ";
                    }
                    if (box2)
                    {
                        sqlCommand.Append(op);
                        sqlCommand.Append("(h.object= 1)");
                        op = " OR ";
                    }
                    if (box3)
                    {
                        sqlCommand.Append(op);
                        sqlCommand.Append("(h.object= 2)");
                    }
                    sqlCommand.AppendLine(")");
                }
