            var GIANTLIST = new List<string>();
            var taskIds = new List<int>();
            Complaint.Tasks.Select(s => s.Task_ID).ForEach(s =>
            {
                taskIds.Add(s);
                GIANTLIST.Add("<Task_ID=" + s.ToString() + ">");
            });
