    public void ExecuteItemClickCommand(Task task)
    {
        //Do stuff with task
        var taskJson = Mvx.Resolve<IMvxJsonConverter>().SerializeObject(task);
        this.ShowViewModel<TaskViewModel>(new TaskViewModel.Parametros { TaskJson = taskJson });
    }
	public IMvxCommand ItemClickCommand
	{
		get
    	{
            return new MvxCommand<Task> (ExecuteItemClickCommand);
        }
    }
