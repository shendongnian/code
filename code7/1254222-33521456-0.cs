    public IEnumerable<StudentDetailss_result> GetStudentDetails(string routeId)
    {
        using(var ctx = new YourContextHere())
        {
            var result = ctx.StudentDetailss(routeId);
            return result.ToList();
        }
    }
