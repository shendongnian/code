        public ActionResult Index(string searchBy, string orderBy, string orderDir)
        {
            var query = fca.GetResultsByFilter(searchBy);
            if (orderBy == "Campus")
            {
                query = (orderDir == "Asc") ? query.OrderBy(s => s.Campus).ThenBy(s => s.Student_Name) :
                    query.OrderByDescending(s => s.Campus);
            }
            else if (orderBy == "Student Name")
            {
                query = (orderDir == "Asc") ? query.OrderBy(s => s.Student_Name) : query.OrderByDescending(s => s.Student_Name);
            }
            else if (orderBy == "Course Count")
            {
                query = (orderDir == "Asc") ? query.OrderBy(s => s.Student_Name) : query.OrderByDescending(s => s.Course_Count);
            }
        }
