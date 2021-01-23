    using System;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;
    using Microsoft.TeamFoundation.Server;
    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.WorkItemTracking.Client;
    using System.Collections.Generic;
    using Microsoft.TeamFoundation.Framework.Common;
    using Microsoft.TeamFoundation.VersionControl.Client;
    
    namespace TFSAPItest
    {
        public partial class Form1 : Form
        {
            public static List<Changeset> BaseChangesets { get; set; }
    
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
                dt.Columns.Add("file_path");
                dt.Columns.Add("filename");
                dt.Columns.Add("project");
                dt.Columns.Add("username");
                dt.Columns.Add("datetime_entered");
                dt.Columns.Add("message");
    
                List<Changeset> FilteredChangesets = new List<Changeset>();
    
                foreach (Changeset c in BaseChangesets)
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
    
                                string ServerItem = ch.Item.ServerItem.Substring(ch.Item.ServerItem.IndexOf('/') + 1, ch.Item.ServerItem.Length - ch.Item.ServerItem.IndexOf('/') - 1);
    
                                dr["file_path"] = ServerItem.Substring(0, ServerItem.LastIndexOf('/'));
                                dr["filename"] = ServerItem.Substring(ServerItem.LastIndexOf('/') + 1, ServerItem.Length - ServerItem.LastIndexOf('/') - 1);
                                dr["project"] = ServerItem.Substring(0, ServerItem.IndexOf('/'));
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
    
            private void BtnGetInformation_Click(object sender, EventArgs e)
            {
                TfsTeamProjectCollection ProjectCollection = new TfsTeamProjectCollection(new Uri("http://example.com:8080/tfs/ProjectCollection"));
    
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
    
                BaseChangesets = Changesets;
    
                if(BaseChangesets != null)
                {
                    GrpDateFilter.Enabled = true;
    
                }
    
            }
    
        }
    
    }
