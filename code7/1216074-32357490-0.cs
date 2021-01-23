    using (StreamWriter file = new StreamWriter(fs))                    
    {
        file.WriteLine( "ProjectID,ProjectTitle,PublishStatus,UsersIDS_Length"); 
    
        for (int index = 0; index < pr.Length; index++)
        {
            var usersIds = db.GetUsersList(pr[s].ProjectID);
            file.WriteLine("{0},\"{1}\",{2},{3}",
               pr[s].ProjectID, pr[s].ProjectTitle,
               pr[s].PublishStatus, usersIds.Length); 
        }
    }
