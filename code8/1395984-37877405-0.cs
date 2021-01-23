            string tfsurl = "http://xxxxxxxxxx/";
            TfsTeamProjectCollection ttpc = new TfsTeamProjectCollection(new Uri(tfsurl));
            WorkItemStore wis = ttpc.GetService<WorkItemStore>();
            WorkItemCollection wic = wis.Query(" SELECT * " + " FROM WorkItems " + "WHERE  [System.TeamProject]='GitBuildRelease' AND [Work Item Type]='Bug'");
            List<WorkItem> wies = new List<WorkItem> { };
            foreach (WorkItem wi in wic)
            {
                foreach (Revision rev in wi.Revisions)
                {
                    if (rev.Fields["Changed By"].Value.ToString() == "yourdisplayname")
                    {
                        wies.Add(rev.WorkItem);
                        break;
                    }
                }
            }
