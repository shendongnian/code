    var dataset = FakeDataset.CreateDataset();
    var projectList = new List<Project>();
    
        foreach (DataTable table in dataset.Tables)
        {
                foreach (DataRow dataRow in table.Rows)
                {
                        if (!projectList.Any(Project => Project.Name == Convert.ToString(dataRow["Name"])))
                        {
                            projectList.Add(new Project { Name = Convert.ToString(dataRow["Name"]), Resource = Convert.ToString(dataRow["Resource"]) });
                        }
                        else
                        {
                            Project p = projectList.Find(Project => Project.Name == Convert.ToString(dataRow["Name"]));
                            projectList[projectList.IndexOf(p)].Resource += "\r\n" + Convert.ToString(dataRow["Name"]);
                        }
                }
         }
