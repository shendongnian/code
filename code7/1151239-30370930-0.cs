        var st = context.tblSystem.FirstOrDefault(c => c.SettingsID == usersID);
        var cca = context.tblOrganisation.FirstOrDefault(c => c.departmentID == usersID);
        if (cca == null)
              {
                st.SettingsID= c.usersID ; 
                st.Settings = c.usersID == userID
               }
