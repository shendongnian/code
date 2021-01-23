    [HttpPut]
    [Route("update")]
    public void Update()
    {
        var task = Task.Run(() => this.engine.Update());
        task.ContinueWith(t => publish(t, "Update()"));
    }
