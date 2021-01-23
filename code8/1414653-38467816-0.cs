        public VtcCommentViewModel(Auth_Admin auth)
        {
            ValidETMResult validEtm = DAL.ValidateETM(auth.CurrentUser, auth.CurrentIP);
            VtcCommentViewModel vm = new VtcCommentViewModel();
    // here you are creating a new object - WRONG!
            vm.EmployeeName = validEtm.emp_name;
            vm.EmployeeNumber = auth.CurrentUser;
            vm.ReaderName = validEtm.rdr_name;
            vm.PunchList = DAL.GetPunchList(auth.CurrentUser);
        }
