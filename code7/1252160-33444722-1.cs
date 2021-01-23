    var listAllData = new List<object>();
    for (var cnt = 0; cnt< 10; cnt++)
    {
        var lstProjectData = new List<object>() //you need to change yours to be new List<ProjectData>
        {
           string.Empty, //CompanyName
           0, //ProjectID
           0 //CorpId
        }; 
           
        lstProjectData [0] = string.Format("CompanyName {0}", cnt);
        lstProjectData [1] = cnt+ 1;
        lstProjectData [2] = cnt+ 2;
        listAllData.Add(lstProjectData );
    //from your List<ProjectData> you should be able to get at the variable
    //as follows someVariable.CompanyName = , 
    //someVariable.ProjectId = , 
    //and someVariable = CorpId
    }
