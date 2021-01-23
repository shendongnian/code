    [HttpGet]
    public JsonResult Get()
    {
        var result = _repo.GetAllForUser("lucas@test.com");
        var response = new {
            categoryId: result.CategoryId,
            name: result.Name,
            timestamp: result.Timestamp,
            username: result.Username,
            tasks: result.Tasks.Select(t => new {
                taskId: t.TaskId,
                name: t.Name,
                timestamp: t.Timestamp
            })
        };
        return Json(response);
    }
