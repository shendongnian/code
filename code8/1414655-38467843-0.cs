            ValidETMResult validEtm = DAL.ValidateETM(auth.CurrentUser, auth.CurrentIP);
            // Wrong! You are creating a new instance which dies when you left the constructor!
            VtcCommentViewModel vm = new VtcCommentViewModel();
            vm.EmployeeName = validEtm.emp_name;
            vm.EmployeeNumber = auth.CurrentUser;
            vm.ReaderName = validEtm.rdr_name;
            vm.PunchList = DAL.GetPunchList(auth.CurrentUser);
