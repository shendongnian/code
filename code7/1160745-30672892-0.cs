                var GIANTLIST = new List<string>();
                var taskIds = new List<int>();
                Complaint.Tasks.Select(s => s.Task_ID).ToList().ForEach( s =>
                {
                    taskIds.Add(s.TASK_ID);
                    GIANTLIST.Add("<Task_ID=" + s.ToString() + ">");
                });
