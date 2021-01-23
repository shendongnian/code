    List<Task> taskList = new List<Task>();
    Task task1=
                Task.Factory.StartNew(() =>
                    var List1 = client1.GetList1(););
    Task task2=
                Task.Factory.StartNew(() =>
                    var List2 = client1.GetList2(););
    // and so forth
            
    taskList.Add(task1);
    taskList.Add(task2);
    Task.WaitAll(taskList.ToArray());
