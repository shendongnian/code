    foreach (var v in usersAssessment)
    {
        var user = users.FirstOrDefault(p => p.Id == v.Id);
        
        if(user != null)
        {
            switch (v.ModuleCode)
            {
                case "M01":
                    // This WILL update the selected user, if users is a collection of reference types.
                    user.M01 = v.ScoreObtained;
                    break;
            }
        }
    }
