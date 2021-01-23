    for (int j=0;j<gvJobs.Columns.Count ;j++)
    {
        if (gvJobs.Columns[j].HeaderText == "Edit")
        {    
             DataGridViewLinkColumn Editlink = new DataGridViewLinkColumn();
             Editlink.UseColumnTextForLinkValue = true;
             Editlink.HeaderText = "Edit";
             Editlink.DataPropertyName = "lnkColumn";
             Editlink.LinkBehavior = LinkBehavior.SystemDefault;
             Editlink.Text = "Edit";
             gvJobs.Columns.Add(Editlink);
         }
                    
     }
