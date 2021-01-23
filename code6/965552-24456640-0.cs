            protected void gvCategory_DataBound(object sender, EventArgs e)
        {
            DataSet myDataset = gvCategory.DataSource as DataSet;
            if (myDataset != null)
            {
                for (int i = 0; i < myDataset.Tables[0].Rows.Count; i++)
                {
                    string TaskGroup = myDataset.Tables[0].Rows[i]["TASKGROUP"].ToString();
                    string TaskCategory = myDataset.Tables[0].Rows[i]["TASKCATEGORY"].ToString();
                    string TaskID = myDataset.Tables[0].Rows[i]["ID"].ToString();
                    // insert a seperator row based on the taskgroup
                    if (TaskGroup != PreviousTaskGroup)
                    {
                        ListItem seperator = new ListItem("--" + TaskGroup + "--", "");
                        seperator.Attributes.Add("disabled", "true");
                        seperator.Enabled = false;
                        listItems.Add(seperator);
                        if (i != myDataset.Tables[0].Rows.Count)
                        {
                            PreviousTaskGroup = myDataset.Tables[0].Rows[i]["TASKGROUP"].ToString();
                            i--;
                        }
                    }
                    else
                    {
                        listItems.Add(new ListItem(" " + TaskCategory, TaskID));
                        if (i != myDataset.Tables[0].Rows.Count)
                        {
                            PreviousTaskGroup = myDataset.Tables[0].Rows[i]["TASKGROUP"].ToString();
                        }
                    }
                }
            }
