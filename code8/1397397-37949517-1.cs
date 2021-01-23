    using (var db = new SampleEntities())
                {
                    var result=db.TableAs.JoinEx<TableA, TableB, int>(db.TableBs, x => x.Id_1, y => y.FK_Id);  
                    foreach(var item in result)
                    {               
                            Console.WriteLine("{0} \t {1}",item.A.Name,item.B.Name2);                                       
                    }
                }
