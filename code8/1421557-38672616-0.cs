    public void Report(DbSyncProgressEventArgs args)
        {
            if (args.ScopeProgress.TotalChangesApplied <= 0)
            {
                intTotalChanges = args.ScopeProgress.TotalChanges;
            }
            listSyncProgress.Items.Clear();
            listSyncProgress.Items.Add("Total Tables  : " + args.ScopeProgress.TablesProgress.Count);
            listSyncProgress.Items.Add("Total Changes : " + intTotalChanges);
            listSyncProgress.Items.Add("Total Applied : " + args.ScopeProgress.TotalChangesApplied);
            listSyncProgress.Items.Add("Table Name    : " + args.TableProgress.TableName);
            listSyncProgress.Items.Add("Total Failed  : " + args.ScopeProgress.TotalChangesFailed);
            Application.DoEvents();
        }
