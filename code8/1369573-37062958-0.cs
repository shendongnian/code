        public void addFisier(DirectorVideo[] directors)
            {
                DbTransaction dbTrans;
                try
                {
                    _dbConnection.Open();
                    
                    // Start Transaction first.
                    dbTrans = _dbConnection.BeginTransaction();
                    for (int i = 0; i < directors.Length - 1; i++)
                    {
                        for (int j = 0; j < directors[i].nrFisiere; j++)
                        {
                            // Create commands that run based on your number of inserts.
                            var dbCommand = new SQLiteCommand();
                            dbCommand.Connection = _dbConnection;
                            dbCommand.CommandText = "insert into Fisiere(Nume, Dimensiune, Data, Rating_imdb, Cale) values(@nume, @dimensiune, @data, @rating_imdb, @cale);";
                            dbCommand.Transaction = dbTrans;
                            var numeParam = new SQLiteParameter("@nume");
                            numeParam.Value = directors[i].fisiere[j].numeFisier;
                            var dimensiuneParam = new SQLiteParameter("@dimensiune");
                            dimensiuneParam.Value = directors[i].fisiere[j].dimensiune;
                            var dataParam = new SQLiteParameter("@data");
                            dataParam.Value = directors[i].fisiere[j].data;
                            var ratingParam = new SQLiteParameter("rating_imdb");
                            IMDb rat = new IMDb(directors[i].fisiere[j].numeFisier);
                            ratingParam.Value = rat;
                            var caleParam = new SQLiteParameter("cale");
                            caleParam.Value = directors[i].cale;
                            Console.WriteLine(numeParam.Value);
                            dbCommand.Parameters.Add(numeParam);
                            dbCommand.Parameters.Add(dimensiuneParam);
                            dbCommand.Parameters.Add(dataParam);
                            dbCommand.Parameters.Add(ratingParam);
                            dbCommand.Parameters.Add(caleParam);
                            Console.WriteLine(caleParam.Value);
                            Console.WriteLine("A fost inserat");
                             
                            // Actually execute the commands.
                            dbCommand.ExecuteNonQuery();
                        }
                    }
                    // If everything is good, commit the transaction.
                    dbTrans.Commit();
                }
                catch (Exception)
                {
                    Console.WriteLine("muie");
                    dbTrans.Rollback();
                    throw;
                }
                finally
                {
                    if (_dbConnection.State != ConnectionState.Closed) _dbConnection.Close();
                }
            }
