    public string GetAllTask()
    {
        var jsonSerialiser = new JavaScriptSerializer();
        List<Dictionary<string, object>> task_list = new List<Dictionary<string, object>>();
        TaskService ts = new TaskService();
        TaskFolder fld = ts.GetFolder("WS");
        foreach (Task task in fld.Tasks)
        {
                task_list.Add(new Dictionary<string, object>());
                //[Populate your new Dictionary object here]
                task_list.Last()["xml"] = task.Definition.RegistrationInfo.Description;
        }
        var ser_task_list = jsonSerialiser.Serialize(task_list);
        return ser_task_list.ToString();
    }
