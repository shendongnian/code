    namespace TFSAPItest
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
                TxtDateFrom.Text = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");
    
                TxtDateTo.Text = DateTime.Now.ToString("dd/MM/yyyy");
    
            }
    
            private void BtnRefresh_Click(object sender, EventArgs e)
            {
                DateTime DateFrom = DateTime.Parse(TxtDateFrom.Text);
    
                DateTime DateTo = DateTime.Parse(TxtDateTo.Text);
    
                DataTable dt = new DataTable();
                dt.Columns.Add("folder_path");
                dt.Columns.Add("filename");
                dt.Columns.Add("username");
                dt.Columns.Add("datetime_entered");
                dt.Columns.Add("message");
                
                TfsTeamProjectCollection ProjectCollection = new TfsTeamProjectCollection(new Uri("http://example.com:8080/tfs/defaultcollection"));
                
                ProjectCollection.Connect(ConnectOptions.None);
    
                var vcs = ProjectCollection.GetService<VersionControlServer>();
    
                VersionSpec versionFrom = VersionSpec.ParseSingleSpec("C529", null);
    
                VersionSpec versionTo = VersionSpec.Latest;
    
                string serverPath = @"$/";
    
                List<Changeset> Changesets = vcs.QueryHistory(serverPath,
                  VersionSpec.Latest,
                  0,
                  RecursionType.Full,
                  null,
                  versionFrom,
                  versionTo,
                  Int32.MaxValue,
                  true,
                  false
                  ).Cast<Changeset>().ToList<Changeset>();
    
                List<Changeset> FilteredChangesets = new List<Changeset>();
    
                foreach (Changeset c in Changesets)
                {
                    if(c.CreationDate > DateFrom && c.CreationDate < DateTo)
                    {
                        FilteredChangesets.Add(c);
    
                    }
    
                }
    
                foreach (Changeset c in FilteredChangesets)
                {
                    List<Change> Changes = c.Changes.ToList<Change>();
                    
                    if (Changes != null && Changes.Count > 0)
                    {
                        foreach (Change ch in Changes)
                        {
                            if (ch.Item.ItemType == ItemType.File)
                            {
                                DataRow dr = dt.NewRow();
    
                                dr["folder_path"] = ch.Item.ServerItem;
                                dr["filename"] = ch.Item.ServerItem;
                                dr["username"] = c.Committer;
                                dr["datetime_entered"] = c.CreationDate.ToString("dd/MM/yyyy HH:mm");
                                dr["message"] = c.Comment;
    
                                dt.Rows.Add(dr);
    
                            }
    
                        }
    
                    }
    
                }
                
                DgvResults.DataSource = dt;
                
            }
    
        }
    
    }
