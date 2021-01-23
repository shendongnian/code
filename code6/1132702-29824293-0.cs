     using (DataClassesDataContext DC = new DataClassesDataContext())
     {
        int CurrentClient = CLD.UserID;
        var Count = DC.tblProjects.Where<tblProject>
                (c => c.ClientID == CurrentClient).Count(); //THIS LINE
         
        lblTotalProjectsAmount.Content = Count;
    }
