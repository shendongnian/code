    [HttpGet]
    [Route("api/department/getndeptsfromid")]
    public List<Department> GetNDepartmentsFromID([FromUri]int FirstId, [FromUri] int CountToFetch)
    {
        return HHSService.GetNDepartmentsFromID(FirstId, CountToFetch);
    }
