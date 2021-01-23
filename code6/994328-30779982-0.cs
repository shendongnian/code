    /// <summary>
        /// Bulk insert some data, uses parameters
        /// </summary>
        /// <param name="table"></param>
        /// <param name="inserts"></param>
        /// <param name="batchSize"></param>
        /// <param name="progress"></param>
        public void BulkInsert(string table, MySQLBulkInsertData inserts, int batchSize = 100, IProgress<double> progress = null)
        {
            if (inserts.Count <= 0) throw new ArgumentException("Nothing to Insert");
            string insertcmd = string.Format("INSERT INTO `{0}` ({1}) VALUES ", table,
                                             inserts.Fields.Select(p => p.FieldName).ToCSV());
            StringBuilder sb = new StringBuilder(); 
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            using (MySqlCommand sqlExecCommand = conn.CreateCommand())
            {
                conn.Open();
                sb.AppendLine(insertcmd);
                for (int i = 0; i < inserts.Count; i++)
                {
                    sb.AppendLine(ToParameterCSV(inserts.Fields, i));
                    for (int j = 0; j < inserts[i].Count(); j++)
                    {
                        sqlExecCommand.Parameters.AddWithValue(string.Format("{0}{1}",inserts.Fields[j].FieldName,i), inserts[i][j]);
                    }
                    //commit if we are on the batch sizeor the last item
                    if (i > 0 && (i%batchSize == 0 || i == inserts.Count - 1))
                    {
                        sb.Append(";");
                        sqlExecCommand.CommandText = sb.ToString();
                        sqlExecCommand.ExecuteNonQuery();
                        //reset the stringBuilder
                        sb.Clear();
                        sb.AppendLine(insertcmd);
                        if (progress != null)
                        {
                            progress.Report((double)i/inserts.Count);
                        }
                    }
                    else
                    {
                        sb.Append(",");
                    }
                }
            }
        }
