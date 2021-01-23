    [HttpGet, Route("activities/{id:int}/assignments")]
    public List<Assignment> List(int id, int page = 1, int pageSize = 50) {
         List<Assignment> assignments = new List<Assignment>();
         assignments.AddRange(Repository.GetStudentAssignments(id).ToExternal(page, pageSize));
         assignments.AddRange(Repository.GetTeacherAssignments(id).ToExternal(page, pageSize));
         return assignments;
    }
