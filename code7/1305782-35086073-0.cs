           foreach (dynamic x in currApplication.CurrentData.AllQueries)
            {
                try
                {
                    var temp = x.CurrentView;
                    Access.AccessObject temp2 = x;
                    Microsoft.Office.Interop.Access.Dao.Database cdb = currApplication.CurrentDb();
                    Microsoft.Office.Interop.Access.Dao.Recordset rst = cdb.OpenRecordset(x.Name);
                    rst.MoveFirst();
                    do
                    {
                        foreach (Microsoft.Office.Interop.Access.Dao.Field field in rst.Fields)
                        {
                            Console.WriteLine(field.Name);
                            Console.WriteLine(field.Value);
                        }
                        rst.MoveNext();
                    } while (rst.EOF != true);
                    /*object[,] z = rst.GetRows();
                    for (int i = 0; i <= z.GetUpperBound(0); i++)
                    {
                        Console.WriteLine(z[i, 0].ToString());
                    }*/
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    
                }
            }
