    using (FileStream fs = new FileStream(outCsvFile, FileMode.Append, FileAccess.Write))
    using (StreamWriter file = new StreamWriter(fs))
    {
        file.WriteLine("ProjectID, ProjectTitle,PublishStatus,NumberOfSubjects,ProjectStartDate,ProjectEndDate,URL");
        foreach(proj in pr.Distinct())
        {
            var userIDs = db.GetList(proj.ProjectID);                
            file.WriteLine("{0},\"{1}\",{2},{3},{4},{5},{6}",
               proj.ProjectID,
               proj.ProjectTitle,
               proj.PublishStatus,
               userIDs.Length,
               proj.ProjectStartDate,
               proj.ProjectEndDate,
               url[i].ToString());
        }
    }
