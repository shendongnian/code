    Class AttendancePresenter 
    {
        public readonly BindingList<IAttendance> AttendanceList = new BindingList<IAttendance>();
        private void AddAttendance()
        {
            AttendanceList.Add(attendanceModel);
        }
        private void GetAttendance()
        {
            AttendanceList.Clear();
            AttendanceList.AddRange(_DataService.GetAttendance());
        }
        private void Save()
        {
            _DataService.InsertAttendance (AttendanceList);
        }
    }
