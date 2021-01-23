    List<Task> tasks = new List<Task>();
	tasks.Add(new Task {TaskID = 1});
	tasks.Add(new Task {TaskID = 3});
	tasks.Add(new Task {TaskID = 5});
	
	List<TaskHistory> taskHistories = new List<TaskHistory>();
	taskHistories.Add(new TaskHistory { TaskID = 3, AssignDate = DateTime.Now });
	taskHistories.Add(new TaskHistory { TaskID = 3, AssignDate = DateTime.Now.AddDays(3) });
	taskHistories.Add(new TaskHistory { TaskID = 1, AssignDate = DateTime.Now });
	taskHistories.Add(new TaskHistory { TaskID = 1, AssignDate = DateTime.Now.AddDays(1) });
	taskHistories.Add(new TaskHistory { TaskID = 1, AssignDate = DateTime.Now.AddDays(4) });
	
	var query = from task in tasks
				join thist in taskHistories on task.TaskID equals thist.TaskID
				group new { t = task, date = thist.AssignDate } by task.TaskID into grouped
				from g in grouped
				where g.date == grouped.Max(taskInGroup => taskInGroup.date)
				select g;
