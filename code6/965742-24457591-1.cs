    Class AttendancePresenter 
    {
        private readonly BindingList<IAttendance> _attendanceList;
        public AttendancePresenter()
        {
            _attendanceList = new BindingList<IAttendance>();
            _View.AttendanceGrid = _attendanceList;
        }
        private void AddAttendance()
        {
            _attendanceList.Add(attendanceModel);
        }
        private void GetAttendance()
        {
            _attendanceList.Clear();
            _attendanceList.AddRange(_DataService.GetAttendance());
        }
        private void Save()
        {
            _DataService.InsertAttendance (_attendanceList);
        }
    }
