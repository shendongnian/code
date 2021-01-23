    [HttpPost]
    public IHttpActionResult Post([FromBody]TaskDto task)
    {
        var job = "";
        if(task.TaskName == "TaskA"){
            job = BackgroundJob.Schedule(() => RunTaskA(task.p1,task.p2), task.StartTime);
        }
        if(task.TaskName == "TaskB"){
            job = BackgroundJob.Schedule(() => RunTaskB(task.p1,task.p2), task.StartTime);
        }
        
        if(!string.IsNullOrWhiteSpace(task.ContinueWith) && !string.IsNullOrWhiteSpace(job)){       
            if(task.ContinueWith == "TaskB"){
                BackgroundJob.ContinueWith(job, () => RunTaskB(task.p3,task.p4));
            }
            if(task.ContinueWith == "TaskA"){
                BackgroundJob.ContinueWith(job, () => RunTaskA(task.p3,task.p4));
            }
        }
        return Ok(job)
    }
