    using (StreamWriter file = new StreamWriter(outCsvFile))
    {
        for (int i = 0; i < pr.Length; ++i)
        {
            string[] subecjtsIDS = new string[] {""};
            subecjtsIDS = db.GetUsersList(pr[i].ProjectID);
            foreach(var id in subecjtsIDS)
            {
                file.WriteLine(pr[i].ProjectID + ',' + pr[i].ProjectTitle + ',' + id );
            }    
        }
    }
