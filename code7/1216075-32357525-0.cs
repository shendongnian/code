    using (StreamWriter file = new StreamWriter(fs))                    
    {
        file.WriteLine("ProjectID, ProjectTitle,PublishStatus,Length");
        for (int s = 0; s < pr.Length; ++s)
        {
            string[] UsersIDS = new string[] {""};
            UsersIDS = db.GetUsersList(pr[s].ProjectID);
            file.WriteLine( pr[s].ProjectID + '"' + ',' + '"' + pr[s].ProjectTitle + '"' + ',' + pr[s].PublishStatus + '"' + ',' + UsersIDS.Length); 
    
    }//end of for
