    using System.Data; // For System.Data.DataTableExtensions
        string projectId = proj.ProjectID;
        var ds = db.GetProjectDetails(language);
        var type = ds.Tables["Table"].AsEnumerable().Where(r => projectId.Equals(r["ProjectId"])).Select(r => r["ProjectType"]).SingleOrDefault();
        // Output the type to the file with the rest of the data.
