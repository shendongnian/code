    [HttpPost]
    [Route("")]
    public async Task<IHttpActionResult> Post([FromBody]Task task)
    {
        task.Notes.Add(DateTime.Now.ToString("F"));
        await _repositoryFactory.TaskRepository.SaveTask(task);
        await _repositoryFactory.SaveChanges();
        return RedirectToRoute("Get", new {id = task.Id});
    }
