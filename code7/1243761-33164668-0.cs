     TableRobots = fn.Table("select * from Robots");
                for (int i = 0; i < dg.Rows.Count; i++)
                {
                    for (int j = 1; j < dg.Columns.Count ; j++)
                    {
                        dg.Rows[i].Cells[j].Value = TableRobots.Select("ID=" + dg.Rows[i].Cells[0].Value)[0][j].ToString();
                    }
                }
