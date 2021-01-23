        public VtcCommentViewModel(Auth_Admin auth)
        {
            ValidETMResult validEtm = DAL.ValidateETM(auth.CurrentUser, auth.CurrentIP);
            // assign values to property of the object you are creating - not a new object
            EmployeeName = validEtm.emp_name;
            EmployeeNumber = auth.CurrentUser;
            ReaderName = validEtm.rdr_name;
            PunchList = DAL.GetPunchList(auth.CurrentUser);
        }
