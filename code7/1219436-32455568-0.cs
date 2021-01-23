        private int? _teacherIndex;
        protected int TeacherIndex
        {
            get
            {
                if (!_teacherIndex.HasValue)
                {
                    var iObject = Session["_teacherIndex"];
                    var i = 0;
                    if (iObject != null)
                    {
                        int.TryParse(iObject.ToString(), out i);
                    }
                    _teacherIndex = i;
                }
                return _teacherIndex.Value;
            }
            set { Session["_teacherIndex"] = value; }
        }
