    string outCsvFile = string.Format(@"C:\\test\\test.csv");
    
    WS.Projects[] pr = db.GetAllProject();
    
    using (StreamWriter file = new StreamWriter(outCsvFile))
    {
        for (int i = 0; i < pr.Length; ++i)
        {
            string[] subecjtsIDS = new string[] {""};
            subecjtsIDS = db.GetUsersList(pr[i].ProjectID);
    
            string formattedSubecjtsIDs;
            for (int j = 0; j < subecjtsIDs.length; j++)
            {
                if (!string.IsNullOrEmpty(formattedSubecjtsIDs))
                    formattedSubecjtsIDs += ", ";
                formattedSubecjtsIDs += subecjtsIDs[j];
            }
            file.WriteLine(pr[i].ProjectID + ',' + pr[i].ProjectTitle + ',' + formattedSubecjtsIDS);                          
    
        }
    }
