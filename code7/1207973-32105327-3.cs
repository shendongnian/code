    var type = _projectService.GetTaskTypeById(id);
    dynamic task;
    switch (type)
    {
        case "MS":
            task = _projectService.GetMSTaskById(id);
            break;
        case "TL":
            task = _projectService.GetTLTaskById(id);
            break;
        case "ET":
            task = _projectService.GetETTaskById(id);
            break;
        default:
            throw new NotSupportedException("Unsupported Task Type: " + type);
    }
    
    task.ToModel();
