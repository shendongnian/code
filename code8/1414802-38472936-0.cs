    from userTable in SBDB.UserTable
    join serviceTable in SBDB.ServiceTable on userTable.ID equals serviceTable.ID
    join specializationTable in SBDB.SpecializationTable on .....
    where ....
    select new PO_Master {
       UserName = usrInfo.UserName;
        UserMail = usrInfo.UserEmail;
        ServiceName = serviceTable.ServiceName;// need to get this from service table
        Specialization = specializationTable.Specialization;// need to get this from specialization table
    }
