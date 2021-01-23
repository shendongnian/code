    int counter = 0;
    foreach(WS.ProjectMetaData proj in pr.Distinct(new ProjectEqualityComparer()))
    {
        // your code here
        var projectInfo = parseXml(ds);
        file.WriteLine("{0},{1}, ... ",
        proj.ProjectID,
        projectInfo[counter],
        // ...
        );
        counter++;
    }
