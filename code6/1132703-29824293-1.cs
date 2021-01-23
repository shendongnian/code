     using (DataClassesDataContext DC = new DataClassesDataContext())
     {
        int CurrentClient = CLD.UserID;
        var Count = DC.tblProjects.Count(c => c.ClientID == CurrentClient); //THIS LINE
         
        lblTotalProjectsAmount.Content = Count;
    }
