    /// <summary>
    ///     For a given a datasource file, add all rows to the DataSet and collect Hexdump data 
    /// </summary>
    /// <param name="ds">
    ///     The <see cref="System.Data.DataSet" /> to add to 
    /// </param>
    /// <param name="file">
    ///     The datasource file to process 
    /// </param>
    internal static void GenerateDatasource(ref DataSet ds, ref FileHelperEngine engine, DataSourceColumnSpecs mktgidSpecs, string file)
    {
        // Some singleton class instances to hold program data I will need.
        singletonSQL sSQL = singletonSQL.sSQL;
        singletonArguments sArgs = singletonArguments.sArgs;
        try
        {
            // Load a DataTable with contents of datasource file.
            DataTable dt = engine.ReadFileAsDT(file);
            // Clean up the DataTable by removing columns that should be ignored.
            DataTableCleanUp(ref dt, ref engine);
            // ReadFileAsDT() makes all of the columns ReadOnly. Fix that.
            foreach (DataColumn column in dt.Columns)
                column.ReadOnly = false;
            // Okay, now get a Primary Key and add in the derived columns.
            GenerateDatasourceSchema(ref dt);
            // Parse all of the rows and columns to do data clean up and assign some custom
            // values. Add custom values for jobID and serial columns to each row in the DataTable.
            for (int row = 0; row < dt.Rows.Count; row++)
            {
                string version = string.Empty; // The file version
                bool found = false; // Used to get out of foreach loops once the required condition is found.
                // Iterate all configured jobs and add the jobID and serial number to each row
                // based upon match.
                foreach (JobSetupDetails job in sSQL.VznJobDescriptions.JobDetails)
                {
                    // Version must match id in order to update the row. Break out once we find
                    // the match to save time.
                    version = dt.Rows[row][dt.Columns[mktgidSpecs.header]].ToString().Trim().Split(new char[] { '_' })[0];
                    foreach (string id in job.ids)
                    {
                        if (version.Equals(id))
                        {
                            dt.Rows[row][dt.Columns["jobid"]] = job.jobID;
                            lock (locklist)
                                dt.Rows[row][dt.Columns["serial"]] = job.serial++;
                            found = true;
                            break;
                        }
                    }
                    if (found)
                        break;
                }
                // Parse all columns to do data clean up.
                for (int column = 0; column < dt.Columns.Count; column++)
                {
                    // This tab character keeps showing up in the data. It should not be there,
                    // but customer won't fix it, so we have to.
                    if (dt.Rows[row][column].GetType() == typeof(string))
                        dt.Rows[row][column] = dt.Rows[row][column].ToString().Replace('\t', ' ');
                }
            }
            dt.AcceptChanges();
            // DataTable is cleaned up and modified. Time to push it into the DataSet.
            lock (locklist)
            {
                // If dt is writing back to the DataSet for the first time, Rows.Count will be
                // zero. Since the DataTable in the DataSet does not have the table schema and
                // since dt.Copy() is not an option (ds is referenced, so Copy() won't work), Use
                // Merge() and use the option MissingSchemaAction.Add to create the schema.
                if (ds.Tables[sSQL.FixedDataDefinition.DataTableName].Rows.Count == 0)
                    ds.Tables[sSQL.FixedDataDefinition.DataTableName].Merge(dt, false, MissingSchemaAction.Add);
                else
                {
                    // If this is not the first write to the DataSet, remove the PrimaryKey
                    // column to avoid duplicate key values. Use ImportRow() rather then .Merge()
                    // since, for whatever reason, Merge() is overwriting ds each time it is
                    // called and ImportRow() is actually appending the row. Ugly, but can't
                    // figure out another way to make this work.
                    dt.PrimaryKey = null;
                    dt.Columns.Remove(dt.Columns[0]);
                    foreach (DataRow dr in dt.Rows)
                        ds.Tables[sSQL.FixedDataDefinition.DataTableName].ImportRow(dr);
                }
                // Accept all the changes made to the DataSet.
                ds.Tables[sSQL.FixedDataDefinition.DataTableName].AcceptChanges();
            }
            // Clean up memory.
            dt.Clear();
            // Log my progress.
            log.GenerateLog("0038", log.Info
                            , engine.TotalRecords.ToString() + " DataRows successfully added for file:\r\n\t"
                            + file + "\r\nto DataTable "
                            + sSQL.FixedDataDefinition.DataTableName);
        }
        catch (Exception e)
        {
            // Something bad happened here.
            log.GenerateLog("0038", log.Error, "Failed to add DataRows to DataTable "
                            + sSQL.FixedDataDefinition.DataTableName
                            + " for file\r\n\t"
                            + file, e);
        }
        finally
        {
            // Successful or not, get rid of the datasource file to prevent other issues.
            File.Delete(file);
        }
    }
