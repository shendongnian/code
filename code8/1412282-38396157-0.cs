    var task1 = Task.Run(() =>
    {
    	try
    	{
    		using (OleDbConnection con1 = new OleDbConnection("Provider=MSDAORA.1;Data Source=db1:1521;Persist Security Info=True;Password=password;User ID=username"))
    		{
    			con1.Open();
    			v1 = 1;
    			con1.Close();
    		}
    	}
    	catch (Exception ex)
    	{
    		v1 = 0;
    	}
    });
    var task2 = Task.Run(() =>
    {
    	try
    	{
    		using (OleDbConnection con2 = new OleDbConnection("Provider=MSDAORA.1;Data Source=db2:1521;Persist Security Info=True;Password=password;User ID=username"))
    		{
    			con2.Open();
    			v2 = 1;
    			con2.Close();
    		}
    	}
    	catch (Exception ex)
    	{
    		v2 = 0;
    	}
    });
    
    // If you need to wait until task1 and task2 finished, then use this:
    List<Task> tasks = new List<Task>();
    tasks.Add(task1);
    tasks.Add(task2);
    Task.WaitAll(tasks.ToArray());
